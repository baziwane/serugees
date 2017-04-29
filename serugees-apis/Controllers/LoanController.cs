using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serugees.Apis.Models;

namespace Serugees.Apis.Controllers
{
    [Route("api/[controller]")]
    public class LoanController : Controller
    {
        private readonly ILoanRegister _loanRepository;
        public LoanController(ILoanRegister loanRepository)
        {
            _loanRepository = loanRepository;
        }
        [HttpGet]
        public IEnumerable<Loan> GetAll()
        {
            return _loanRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetLoan")]
        public IActionResult GetById(int id)
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
            return CreatedAtRoute("GetLoan", new { id = item.LoanId }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Loan item)
        {
            if (item == null || item.LoanId != id)
            {
                return BadRequest();
            }

            var loansRepo = _loanRepository.Find(id);
            if (loansRepo == null)
            {
                return NotFound();
            }

            loansRepo.IsActive = item.IsActive;
            loansRepo.LoanId = item.LoanId;

            _loanRepository.Update(loansRepo);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
