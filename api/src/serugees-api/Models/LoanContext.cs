using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serugees_api.Models
{
    public class LoanContext: DbContext
    {
         public LoanContext(DbContextOptions<LoanContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> allLoans { get; set; }
    }
}