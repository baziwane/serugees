using System.Collections.Generic;

namespace serugees_api.Models
{
    public interface ILoanRepository
    {
        void Add(Loan item);
        IEnumerable<Loan> GetAll();
        Loan Find(long key);
        void Remove(long key);
        void Update(Loan item);
    }
}