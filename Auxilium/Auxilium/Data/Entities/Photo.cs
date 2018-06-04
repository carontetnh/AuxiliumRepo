using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auxilium.Data.Entities
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}