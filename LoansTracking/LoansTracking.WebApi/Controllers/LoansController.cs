using System;
using System.Linq;
using System.Web.Http;
using LoansTracking.DB.Entities;
using LoansTracking.DB.DataAccess;
using LoansTracking.WebApi.Models;

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
                    return NotFound();
                }
                else
                {
                    return Ok(Factory.Create(loan));
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Repository.Get().ToList().Select(x => Factory.Create(x)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Post(LoanModel model)
        {
            try
            {
                Loan Loan = Parser.Create(model, Repository.BaseContext());
                Repository.Insert(Loan);
                var newLoan =Repository.Get().OrderByDescending(x => x.Id).FirstOrDefault();
                return Ok(Factory.Create(newLoan));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Put(int id, LoanModel model)
        {
            try
            {
                Loan loan = Repository.Get(id);
                if (loan == null)
                {
                    return NotFound();
                }                 
                else
                {
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), loan.Id);
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
                Loan loan = Repository.Get(id);
                if (loan == null)
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
