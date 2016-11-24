using LoansTracking.DB.DataAccess;
using LoansTracking.DB.Entities;
using LoansTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoansTracking.WebApi.Controllers
{
    public class PaymentsController : BaseController<Payment>
    {
        public PaymentsController(Repository<Payment> depo) : base(depo) { }

        public IHttpActionResult Post(PaymentModel model)
        {
            try
            {
                var loan = Factory.Create(new Repository<Loan>(Repository.BaseContext()).Get(model.LoanId));
                model.PaidById = loan.PersonLoanedTo;
                Payment payment = Parser.Create(model, Repository.BaseContext());
                              
                Repository.Insert(payment);
                                
                if (loan.Status <= 0)
                {
                    loan.PaidOff = true;
                    new Repository<Loan>(Repository.BaseContext()).Update(Parser.Create(loan, Repository.BaseContext()), loan.Id);
                }
                else
                {
                    loan.PaidOff = false;
                    new Repository<Loan>(Repository.BaseContext()).Update(Parser.Create(loan, Repository.BaseContext()), loan.Id);
                }
                return Ok(Factory.Create(payment));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Put(int id, PaymentModel model)
        {
            try
            {
                Payment payment = Repository.Get(id);
                if (payment == null)
                {
                    return NotFound();
                }
                else
                {
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), payment.Id);

                    var loan = Factory.Create(new Repository<Loan>(Repository.BaseContext()).Get(payment.Loan.Id));

                    if (loan.Status <= 0)
                    {
                        loan.PaidOff = true;
                        new Repository<Loan>(Repository.BaseContext()).Update(Parser.Create(loan, Repository.BaseContext()), loan.Id);
                    }
                    else
                    {
                        loan.PaidOff = false;
                        new Repository<Loan>(Repository.BaseContext()).Update(Parser.Create(loan, Repository.BaseContext()), loan.Id);
                    }
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Payment payment = Repository.Get(id);
                if (payment == null)
                {
                    return NotFound();
                }
                else
                {
                    
                    Repository.Delete(id);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}