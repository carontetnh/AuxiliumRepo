using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auxilium.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auxilium.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private IAuxRepository _repository;

        public MemberController(IAuxRepository repo)
        {
            _repository = repo;
        }
        public ActionResult EditProfile()
        {
            var data = _repository.GetProfileForEdit(User.Identity.Name);
                
            return View(data);
        }
    }
}