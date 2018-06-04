using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Auxilium.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string Email { get; set; }
        public string Birthday { get; set; }
        public string Genre { get; set; }
    }
}
