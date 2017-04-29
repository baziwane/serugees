using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using serugees_api.Models;

namespace serugees_api.Controllers
{
    [Route("api/[controller]")]
    public class LoanController : Controller
    {
        private readonly ILoanRepository _loanRepository;
        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        [HttpGet]
        public IEnumerable<Loan> GetAll()
        {
            return _loanRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetLoan")]
        public IActionResult GetById(long id)
        {
            var item = _loanRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Loan item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _loanRepository.Add(item);
            return CreatedAtRoute("GetLoan", new { id = item.Key }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Loan item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var loansRepo = _loanRepository.Find(id);
            if (loansRepo == null)
            {
                return NotFound();
            }

            loansRepo.IsActive = item.IsActive;
            loansRepo.Key = item.Key;

            _loanRepository.Update(loansRepo);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _loanRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _loanRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
