using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auxilium.Data;
using Auxilium.Data.Entities;
using Auxilium.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Auxilium.Controllers
{
    public class AppController : Controller
    {
        private IAuxRepository _repository;
        private UserManager<Member> _userManager;

        public AppController(IAuxRepository repo, UserManager<Member> userManager)
        {
            _repository = repo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Match", "App");
            }

            return RedirectToAction("Login","Account");
        }

        [Authorize]
        public IActionResult Match()
        {
            //var user = User.Identity;
            //throw new InvalidOperationException("Bad things happened");
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        //[HttpPost("contact")]
        //public IActionResult Contact(ContactViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //send the mail
        //        _mailService.SendMessage(model.Email, model.Subject, model.Message);
        //        ViewBag.UserMessage = "Mail Sent";
        //        ModelState.Clear();

        //    }
        //    return View();
        //}

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //[Authorize]
        //public IActionResult Shop()
        //{
        //    //var results = _context.Products
        //    //    .OrderBy(p => p.Category)
        //    //    .ToList();

        //    var results = _repository.GetAllProducts();

        //    return View(results.ToList());
        //}
    }
}