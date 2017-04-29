using System;
using System.Collections.Generic;
using System.Linq;

namespace serugees_api.Models
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanContext _context;

        public LoanRepository(LoanContext context)
        {
            _context = context;

            if( _context.allLoans.Count() == 0)
                Add(new Loan { Amount = 2500000,DurationInMonths=3, MembersId=2, IsActive=true  });
        }

        public IEnumerable<Loan> GetAll()
        {
            return _context.allLoans.ToList();
        }

        public void Add(Loan item)
        {
            _context.allLoans.Add(item);
            _context.SaveChanges();
        }

        public Loan Find(long key)
        {
            return _context.allLoans.FirstOrDefault(t => t.Key == key);
        }

        public void Remove(long key)
        {
            var entity = _context.allLoans.First(t => t.Key == key);
            _context.allLoans.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Loan item)
        {
            _context.allLoans.Update(item);
            _context.SaveChanges();
        }
    }
}