using System;
using System.Linq;
using System.Web.Http;
using LoansTracking.DB.Entities;
using LoansTracking.DB.DataAccess;
using LoansTracking.WebApi.Models;
using System.Collections.Generic;

namespace LoansTracking.WebApi.Controllers
{
    public class LoansController : BaseController<Loan>
    {
        public LoansController(Repository<Loan> depo) : base(depo) { }

        public IHttpActionResult GetByID(int id)
        {
            try
            {
                Loan loan = Repository.Get(id);
                if (loan == null)
                {
                    return BadRequest("Loan not found");
                }
                else
                {
                    return Ok(Factory.Create(loan));
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong !");
            }
        }
        [Route("api/all/loans/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var loans = Repository.Get().Where(x => !x.PaidOff && x.PersonLoanedFrom.Id == id).ToList().Select(x => Factory.Create(x)).ToList();
                return Ok(loans);
            }
            catch (Exception ex)
            {
                return BadRequest("Loans could not be loaded");
            }
        }

        public IHttpActionResult Post(LoanModel model)
        {
            try
            {
                if (Repository.Get().Where(x => x.PersonLoanedTo.FirstName == model.PersonLoanedToName && x.PersonLoanedTo.LastName == model.PersonLoanedToSurname).FirstOrDefault() == null)
                {
                    new Repository<Person>(Repository.BaseContext()).Insert(new Person()
                    {
                        FirstName = model.PersonLoanedToName,
                        LastName = model.PersonLoanedToSurname,
                        DateOfBirth = DateTime.Now.AddYears(-DateTime.Now.Second),
                        Email = model.PersonLoanedToName + "test",
                        Password = "dGVzdA=="
                    });
                }
                model.PersonLoanedTo = new Repository<Person>(Repository.BaseContext()).Get().Where(x => x.FirstName == model.PersonLoanedToName && x.LastName == model.PersonLoanedToSurname).Select(x => x.Id).FirstOrDefault();
                var sameLoans = Repository.Get().Where(x => x.PersonLoanedFrom.Id == model.PersonLoanedFrom && x.PersonLoanedTo.Id == model.PersonLoanedTo && !x.PaidOff).FirstOrDefault();
                if (sameLoans == null)
                {
                    Loan Loan = Parser.Create(model, Repository.BaseContext());
                    Repository.Insert(Loan);
                    var newLoan = Repository.Get().OrderByDescending(x => x.Id).FirstOrDefault();
                    return Ok(Factory.Create(newLoan));
                }
                else
                {
                    return BadRequest("You have already lend money to this person");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Loan could not be saved");
            }
        }

        public IHttpActionResult Put(int id, LoanModel model)
        {
            try
            {
                Loan loan = Repository.Get(id);
                if (loan == null)
                {
                    return BadRequest("Loan not found");
                }
                else
                {
                    var loanedTo = new Repository<Person>(Repository.BaseContext()).Get(model.PersonLoanedTo);
                    if (model.PersonLoanedToName != loanedTo.FirstName || model.PersonLoanedToSurname != loanedTo.LastName)
                    {
                        loanedTo.FirstName = model.PersonLoanedToName;
                        loanedTo.LastName = model.PersonLoanedToSurname;
                        new Repository<Person>(Repository.BaseContext()).Update(loanedTo, loanedTo.Id);            
                    }
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), loan.Id);
                    var newLoan = Factory.Create(Repository.Get(model.Id));
                    if(newLoan.Status <= 0)
                    {
                        newLoan.PaidOff = true;
                        Repository.Update(Parser.Create(newLoan,Repository.BaseContext()), newLoan.Id);
                    }
                    else
                    {
                        newLoan.PaidOff = false;
                        Repository.Update(Parser.Create(newLoan, Repository.BaseContext()), newLoan.Id);
                    }
                    return Ok(newLoan);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Loan could not be updated");
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Loan loan = Repository.Get(id);
                if (loan == null)
                {
                    return BadRequest("Loan not found");
                }                   
                else
                {
                    List<Payment> payments = new List<Payment>();
                    payments.AddRange(loan.Payments);
                    foreach(var payment in payments)
                    {
                        new Repository<Payment>(Repository.BaseContext()).Delete(payment.Id);
                    }
                    Repository.Delete(id);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Loan could not be deleted");
            }
        }
    }
}
