using System;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.EntityFrameworkCore

namespace Serugees.Apis.Models
{
    public class LoanRegistry : ILoanRegistry
    {
        private readonly SerugeesDbContext _context;
        public LoanRegistry(SerugeesDbContext context)
        {
            _context = context;

            if( _context.Loans.Count() == 0)
                Add(new Loan { Amount = 2500000,DurationInMonths=3, MemberId=2, DateRequested=System.DateTime.Now, IsActive=true  });
        }
        public IEnumerable<Loan> GetAll()
        {
            return _context.Loans.ToList();
        }
        public void Add(Loan item)
        {
            _context.Loans.Add(item);
            _context.SaveChanges();
        }
        public Loan Find(int key)
        {
            return _context.Loans.FirstOrDefault(t => t.LoanId == key);
        }
        public void Remove(int key)
        {
            var entity = _context.Loans.First(t => t.LoanId == key);
            _context.Loans.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(Loan item)
        {
            _context.Loans.Update(item);
            _context.SaveChanges();
        }
    }
}