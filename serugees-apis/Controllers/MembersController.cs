using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serugees.Apis.Models;

namespace Serugees.Apis.Controllers
{
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private readonly IMemberRegistry _memberRegister;
        public MembersController(IMemberRegistry members)
        {
            _memberRegister = members;
        }
        [HttpGet]
        public IEnumerable<Member> GetAll()
        {
            return _memberRegister.GetAllMembers();
        }

        [HttpGet("{id}", Name = "Retrieve")]
        public IActionResult Get(int id)
        {
            var item = _memberRegister.SearchByMemberId(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Member member)
        {
            if (member == null)
            {
                return BadRequest();
            }
            _memberRegister.Add(member);
            return CreatedAtRoute("Search", new { id = member.MemberId }, member);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Member member)
        {
            if (member == null || member.MemberId != id)
            {
                return BadRequest();
            }
            // Search for member in the registry
            var searchResult = _memberRegister.SearchByMemberId(id);
            if (searchResult == null)
            {
                return NotFound();
            }

            searchResult.FirstName = member.FirstName;
            searchResult.LastName = member.LastName;
            searchResult.JoinDate = member.JoinDate;
            searchResult.LoginName = member.LoginName;
            searchResult.IsActive = member.IsActive;
            searchResult.MemberId = member.MemberId;

            _memberRegister.UpdateMember(searchResult);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _memberRegister.SearchByMemberId(id);
            if (todo == null)
            {
                return NotFound();
            }

            _memberRegister.Unsubscribe(id);
            return new NoContentResult();
        }
    }
}
