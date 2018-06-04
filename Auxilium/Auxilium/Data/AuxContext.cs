using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auxilium.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Auxilium.Data
{
    public class AuxContext : IdentityDbContext<Member>
    {
        public AuxContext(DbContextOptions<AuxContext> options) : base (options)
        {

        }

        public DbSet<Member> Member { get; set; }

        public DbSet<Member> Profile { get; set; }
    }
}
