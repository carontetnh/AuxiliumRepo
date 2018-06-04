using Auxilium.Data;
using Auxilium.Data.Entities;
using Auxilium.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auxilium.Controllers
{
    public class AccountController : Controller
    {
        private ILogger<AccountController> _logger;
        private SignInManager<Member> _signInManager;
        private UserManager<Member> _userManager;
        private IConfiguration _config;
        private AuxContext _ctx;

        public AccountController(ILogger<AccountController> logger,
            SignInManager<Member> signInManager,
            UserManager<Member> userManager,
            IConfiguration config,
            AuxContext ctx)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _ctx = ctx;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Match", "App");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,
                    model.Password,
                    model.RememberMe,
                    false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUlr"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Match", "App");
                    }
                }
            }

            ModelState.AddModelError("", "Failed to login");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ctx.Database.EnsureCreated();

                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    user = new Member()
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        Profile = new Profile()
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                        }
                    };


                    var results = await _userManager.CreateAsync(user, model.NewPassword);

                    if (results != IdentityResult.Success)
                    {
                        ModelState.AddModelError("", "Failed to create default user");
                        return RedirectToAction("Login", "Account");
                    }
                }

                var result = await _signInManager.PasswordSignInAsync(model.Email,
                    model.NewPassword,
                    false,
                    false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Match", "App");
                }
            }

            ModelState.AddModelError("", "Failed to login");

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _config["Tokens:Issuer"],
                            _config["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(20),
                            signingCredentials: creds
                            );

                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiation = token.ValidTo
                        };

                        return Created("", results);
                    }
                }

            }

            return BadRequest();
        }
    }
}
