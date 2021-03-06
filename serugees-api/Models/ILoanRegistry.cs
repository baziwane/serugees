using System.Collections.Generic;

namespace Serugees.Apis.Models
{
    public interface ILoanRegistry
    {
        void Add(Loan item);
        IEnumerable<Loan> GetAll();
        Loan Find(int key);
        void Remove(int key);
        void Update(Loan item);
    }
}