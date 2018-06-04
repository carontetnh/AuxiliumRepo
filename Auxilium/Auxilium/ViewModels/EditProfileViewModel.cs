using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Auxilium.ViewModels
{
    public class EditProfileViewModel
    {
        public int Id { get; set; }
        public string Pitch { get; set; }

        [DisplayName("Looking For")]
        public string LookingFor { get; set; }

        public string Introduction { get; set; }

        [DisplayName("Birthday")]
        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public string MemberName { get; set; }

        [DisplayName("Sexual Orientation")]
        public string Orientation { get; set; }
    }
}
