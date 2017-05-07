using System;
using System.Collections.Generic;
using System.Linq;

namespace Serugees.Apis.Models
{
    public class MemberRegistry : IMemberRegistry
    {
        private readonly SerugeesDbContext _context;
        public MemberRegistry(SerugeesDbContext context)
        {
            _context = context;
           /* if( _context.Loans.Count() == 0)
                Add(new Member { Amount = 2500000,DurationInMonths=3, MembersId=2, IsActive=true  });*/
        }
        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }
        public void Add(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }
        public Member SearchByMemberId(int memberId)
        {
            return _context.Members.FirstOrDefault(m => m.MemberId == memberId);
        }
        public void Unsubscribe(int memberId)
        {
            var entity = _context.Members.First(m => m.MemberId == memberId);
            _context.Members.Remove(entity);
            _context.SaveChanges();
        }
        public void UpdateMember(Member member)
        {
            _context.Members.Update(member);
            _context.SaveChanges();
        }
    }
}