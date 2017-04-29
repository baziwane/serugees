using System.Collections.Generic;

namespace Serugees.Apis.Models
{
    public interface IMember
    {
        void Subscribe(Member member);
        IEnumerable<Member> GetAll();
        Member Find(int key);
        void Remove(int key);
        void Update(Member item);
    }
}