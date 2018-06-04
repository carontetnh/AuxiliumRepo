using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auxilium.Data.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public int MemberId { get; set; }

        public DateTime DateFavorited { get; set; }
    }
}