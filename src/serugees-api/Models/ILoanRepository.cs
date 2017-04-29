using System.Collections.Generic;

namespace serugees_api.Models
{
    public interface ILoanRepository
    {
        void Add(Loan item);
        IEnumerable<Loan> GetAll();
        Loan Find(int key);
        void Remove(int key);
        void Update(Loan item);
    }
}