using Xunit;
using Microsoft.AspNetCore.Mvc;
using Serugees.Apis.Controllers;
using Serugees.Apis.Models;

namespace Serugees.Apis.UnitTests
{
    public class LoanRegistryControllerTests
    {
        //arrange
        private readonly LoanController _controller;
        private ILoanRegistry _stubs;

        public LoanRegistryControllerTests()
        {
            _stubs = new LoanRegistryStubs();
            _controller = new LoanController(_stubs);
        }

        [Fact]
        public void shouldAddNewLoanToRegistryWhenCalled()
        {
            // act
            Loan newLoan = ((ObjectResult)_controller.GetById(2)).Value as Loan;
            // assert
            Assert.Equal(2500000, newLoan.Amount);
        }        
        public void loanAmountShouldNotEqualToZero()
        {

        }

        public void shouldValidateThatMemberExists()
        {

        }

        public void shouldUpdateExistingLoanWhenCalled()
        {

        }
        public void shouldDeleteAnExistingLoanWhenCalled()
        {

        }

    }
}