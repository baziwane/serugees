using Xunit;
using Microsoft.AspNetCore.Mvc;
using Serugees.Apis.Controllers;
using System;
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
           // _stubs = new LoanRegistry();
           // _controller = new LoanController(_stubs);
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
            throw new NotImplementedException();
        }

        public void shouldValidateThatMemberExists()
        {
            throw new NotImplementedException();
        }

        public void shouldUpdateExistingLoanWhenCalled()
        {
            throw new NotImplementedException();
        }
        public void shouldDeleteAnExistingLoanWhenCalled()
        {
            throw new NotImplementedException();
        }

    }
}