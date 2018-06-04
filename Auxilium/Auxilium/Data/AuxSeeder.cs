using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Auxilium.Data.Entities;

namespace Auxilium.Data
{
    public class AuxSeeder
    {
        private AuxContext _ctx;
        private IHostingEnvironment _hosting;
        private UserManager<Member> _userManager;

        public AuxSeeder(AuxContext ctx, IHostingEnvironment hosting, UserManager<Member> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("ricardo.salinas91@gmail.com");

            if (user == null)
            {
                user = new Member()
                {
                    UserName = "rflores",
                    Email = "ricardo.salinas91@gmail.com",
                    Profile = new Profile()
                    {
                        FirstName = "Ricardo",
                        LastName = "Salinas",
                    }
                };


                var results = await _userManager.CreateAsync(user, "P@ssw0rd!");

                if (results != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
            }

            //Members Seeder
        }
    }
}
