using Xunit;
using Microsoft.AspNetCore.Mvc;
using Serugees.Apis.Controllers;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Moq;
using System.Linq;
using Serugees.Apis.Models;

namespace Serugees.Apis.UnitTests
{
    class FakeLoanRepository : ILoanRegistry {
            public IEnumerable<Loan> Loans { get; } = new Loan[] {
                new Loan { LoanId=2, Amount = 2500000, DurationInMonths=3, MemberId=2, DateRequested=System.DateTime.Now, IsActive=true },
                new Loan { LoanId=3, Amount = 400000, DurationInMonths=1, MemberId=4, DateRequested=System.DateTime.Now, IsActive=true  },
                new Loan { LoanId=1, Amount = 6000000, DurationInMonths=3, MemberId=1, DateRequested=System.DateTime.Now, IsActive=false }
            };
            public void Add(Loan item){
                //Loans.Add(item);
            }
            public IEnumerable<Loan> GetAll() {
                return Loans;
            }
            public Loan Find(int key){
              var data = Loans.Where(ts => ts.LoanId == key).ToList();
              //var data = Loans.FirstOrDefault(e => e.LoanId == key);
              return data[0];
            }
            public void Remove(int key){

            }
            public void Update(Loan item){
                
            }
    }
    public class LoanRegistryTests
    {
        [Fact]
        public void shouldChangeLoanAmountWhenInvoked()
        {
            Loan fakeLoan = new Loan { LoanId=2, Amount = 2500000, DurationInMonths=3, MemberId=2, DateRequested=System.DateTime.Now, IsActive=true };
            fakeLoan.Amount = 5000000;
            Assert.Equal(5000000, fakeLoan.Amount);
        }

        [Fact]
        public void shouldChangeLoanDurationWhenInvoked()
        {
            Loan fakeLoan = new Loan { LoanId=2, Amount = 2500000, DurationInMonths=3, MemberId=2, DateRequested=System.DateTime.Now, IsActive=true };
            fakeLoan.DurationInMonths = 10;
            Assert.Equal(10, fakeLoan.DurationInMonths);
        }

        [Fact]
        public void shouldMakeLoanInactiveWhenInvoked()
        {
            Loan fakeLoan = new Loan { LoanId=2, Amount = 2500000, DurationInMonths=3, MemberId=2, DateRequested=System.DateTime.Now, IsActive=true };
            fakeLoan.IsActive = false;
            Assert.Equal(false, fakeLoan.IsActive);
        }
        [Fact]
        public void shouldRetrieveLoanFromRegistryWhenCalled()
        {
           
            //throw new NotImplementedException();
            var fakeLoanRepo = new FakeLoanRepository();
            /*Mock<ILoanRegistry> fakeLoanRepo = new Mock<ILoanRegistry>();
            fakeLoanRepo.Setup(flr => flr.GetAll()).Returns(new List<Loan>
            {
                new Loan { LoanId=2, Amount = 2500000, DurationInMonths=3, MemberId=2, DateRequested=System.DateTime.Now, IsActive=true },
                new Loan { LoanId=3, Amount = 400000, DurationInMonths=1, MemberId=4, DateRequested=System.DateTime.Now, IsActive=true  },
                new Loan { LoanId=1, Amount = 6000000, DurationInMonths=3, MemberId=1, DateRequested=System.DateTime.Now, IsActive=false }
            });*/
            var _controller = new LoansController(fakeLoanRepo);
            // ACT - call our method under test
            var result =  (ObjectResult) _controller.GetById(1); 
            Loan model = result.Value as Loan;        
            Assert.Equal(6000000, model.Amount);
            Assert.Equal(1, model.MemberId);
        } 

        /*[Fact]
        public void shouldUpdateExistingLoanWhenCalled()
        {
            throw new NotImplementedException();
        }
        [Fact]        
        public void shouldDeleteAnExistingLoanWhenCalled()
        {
            throw new NotImplementedException();
        }*/
         private List<Loan> GetFakeLoans()
        {
           return new List<Loan>
            {
                new Loan { LoanId=2, Amount = 2500000, DurationInMonths=3, MemberId=2, DateRequested=System.DateTime.Now, IsActive=true },
                new Loan { LoanId=3, Amount = 400000, DurationInMonths=1, MemberId=4, DateRequested=System.DateTime.Now, IsActive=true  },
                new Loan { LoanId=1, Amount = 6000000, DurationInMonths=3, MemberId=1, DateRequested=System.DateTime.Now, IsActive=false }
            };
        }


    }
}