using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Auxilium.Data.Entities
{
    public class Member : IdentityUser
    {
        //Asp.net to Authentication & Authorization
        public string FacebookId { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime Created { get; set; }

        public Profile Profile{get; set;}

        public ICollection<Message> Messages { get; set; }

        public ICollection<Favorite> Favorite { get; set; }
    }
}
