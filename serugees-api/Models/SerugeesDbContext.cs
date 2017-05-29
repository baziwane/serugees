using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serugees.Apis.Models
{
    public class SerugeesDbContext: DbContext
    {
         public SerugeesDbContext(DbContextOptions<SerugeesDbContext> options)
            : base(options)
        {
        }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}