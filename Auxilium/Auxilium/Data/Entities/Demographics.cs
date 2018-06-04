using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Auxilium.Data.Entities
{
    public class Demographics
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string CityTown { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [DisplayName("BirthDay")]
        public DateTime Birthdate { get; set; }
        public string Orientation { get; set; }
        public string Gender { get; set; }
    }
}