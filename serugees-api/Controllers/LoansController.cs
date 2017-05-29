using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serugees.Apis.Models;
using Microsoft.Extensions.Logging;

namespace Serugees.Apis.Controllers
{
    [Route("api/[controller]")]
    public class LoansController : Controller
    {
        private readonly ILoanRegistry _loanRepository;
        //private readonly ILogger _logger;

        public LoansController(ILoanRegistry loanRepository/*, ILogger<LoansController> logger*/)
        {
            _loanRepository = loanRepository;
            //_logger = logger;
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
            //_logger.LogDebug("Requesting loan {0}", id);
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
            //_logger.LogDebug("{0} has requested Loan amount UGX {1}", item.MemberId, item.Amount);
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

            var loan = _loanRepository.Find(id);
            if (loan == null)
            {
                return NotFound();
            }

            loan.IsActive = item.IsActive;
            loan.LoanId = item.LoanId;
            loan.Amount = item.Amount;
            loan.DateRequested = System.DateTime.Now;
            loan.DurationInMonths = item.DurationInMonths;
            _loanRepository.Update(loan);
            //_logger.LogDebug("{0} has updated Loan amount UGX {1}", loan.MemberId, loan.Amount);
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
            //_logger.LogDebug("Loan {0} has been removed", id);
            return new NoContentResult();
        }
    }
}
