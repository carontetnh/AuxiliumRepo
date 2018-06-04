using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Auxilium.Data.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LookingFor { get; set; }
        //Short description about the person
        public string Introduction { get; set; }
        //Long description of the person
        public string Pitch { get; set; }

        public Member Member { get; set; }

        public Demographics Demographics { get; set; }
        public ICollection<Interest> Interesets { get; set; }
        public ICollection<Photo> Photo { get; set; }

    }
}