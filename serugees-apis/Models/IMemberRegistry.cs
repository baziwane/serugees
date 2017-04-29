using System.Collections.Generic;

namespace Serugees.Apis.Models
{
    public interface IMemberRegistry
    {
        void Add(Member member);
        IEnumerable<Member> GetAllMembers();
        Member SearchByMemberId(int memberId);
        void Unsubscribe(int memberId);
        void UpdateMember(Member member);
    }
}