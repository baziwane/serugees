using Xunit;
using Microsoft.AspNetCore.Mvc;
using Serugees.Apis.Controllers;
using System;
using System.Collections.Generic;
using Moq;
using Serugees.Apis.Models;

namespace Serugees.Apis.UnitTests
{
    public class LoanRegistryTests
    {
        public LoanRegistryTests()
        {
           // _stubs = new LoanRegistry();
           // _controller = new LoanController(_stubs);
        }

        [Fact]
        public void shouldValidateThatLoanAmountNotZero()
        {
            // Arrange
            var mockRepo = new Mock<ILoanRegistry>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetTestLoans());
            var controller = new LoansController(mockRepo.Object);
            // Act
            Loan result = ((ObjectResult)controller.Get(2)).Value as Loan;
            // Assert
            Assert.Equal(2500000, result.Amount);
            Assert.Equal(2,result.MemberId);
            Assert.True(result.IsActive);
        }
        private List<Loan> GetTestLoans()
        {
            var loans = new List<Loan>();
            loans.Add(new Loan { 
                LoanId=2, 
                Amount = 2500000,
                DurationInMonths=3, 
                MemberId=2, 
                DateRequested=System.DateTime.Now, 
                IsActive=true  
                });
            loans.Add(new Loan { 
                LoanId=3, 
                Amount = 400000,
                DurationInMonths=1, 
                MemberId=4, 
                DateRequested=System.DateTime.Now, 
                IsActive=true  
                });
            loans.Add(new Loan { 
                LoanId=1, 
                Amount = 6000000,
                DurationInMonths=3, 
                MemberId=1, 
                DateRequested=System.DateTime.Now, 
                IsActive=false  
                });

            
            return loans;
        }
        [Fact]
        public void shouldAddNewLoanToRegistryWhenCalled()
        {
            throw new NotImplementedException();
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