using Xunit;
using Microsoft.AspNetCore.Mvc;
using Serugees.Apis.Controllers;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Moq;
using Serugees.Apis.Models;

namespace Serugees.Apis.UnitTests
{
    public class LoanRegistryTests
    {
        private readonly Mock<SerugeesDbContext> _dbContextMock = new Mock<SerugeesDbContext>();
        public LoanRegistryTests()
        {
           // _stubs = new LoanRegistry();
           // _controller = new LoanController(_stubs);
        }

        [Fact]
        public void shouldValidateThatLoanAmountNotZero()
        {
            Loan fakeLoan = new Loan { LoanId=2, Amount = 2500000, DurationInMonths=3, MemberId=2, DateRequested=System.DateTime.Now, IsActive=true };
            Mock<DbSet<Loan>> loanDbSetMock = DbSetMock.Create(fakeLoan);
            _dbContextMock.Setup(x => x.Loans).Returns(loanDbSetMock.Object);
            ILoanRegistry registry = new LoanRegistry(_dbContextMock.Object);
            // Act
            Loan result = registry.Find(2);
            // Assert
            Assert.Equal(2500000, result.Amount);
            Assert.Equal(2,result.MemberId);
            Assert.True(result.IsActive);
        }
       private List<Loan> GetFakeLoans()
        {
           return new List<Loan>
            {
                new Loan { LoanId=2, Amount = 2500000, DurationInMonths=3, MemberId=2, DateRequested=System.DateTime.Now, IsActive=true },
                new Loan { LoanId=3, Amount = 400000, DurationInMonths=1, MemberId=4, DateRequested=System.DateTime.Now, IsActive=true  },
                new Loan { LoanId=1, Amount = 6000000, DurationInMonths=3, MemberId=1, DateRequested=System.DateTime.Now, IsActive=false }
            };
        }
      /*   [Fact]
        public void shouldAddNewLoanToRegistryWhenCalled()
        {
            throw new NotImplementedException();
        } 
        [Fact]       
        public void loanAmountShouldNotEqualToZero()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public void shouldValidateThatMemberExists()
        {
            throw new NotImplementedException();
        }

        public void shouldUpdateExistingLoanWhenCalled()
        {
            throw new NotImplementedException();
        }
        [Fact]        
        public void shouldDeleteAnExistingLoanWhenCalled()
        {
            throw new NotImplementedException();
        }*/

    }
}