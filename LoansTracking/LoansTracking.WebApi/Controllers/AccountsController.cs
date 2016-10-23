using LoansTracking.DB.DataAccess;
using LoansTracking.DB.Entities;
using LoansTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LoansTracking.WebApi.Controllers
{
    public class AccountsController : BaseController<Account>
    {
        public AccountsController(Repository<Account> depo) : base(depo) { }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Repository.Get().ToList().Select(x => Factory.Create(x)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post(AccountModel model)
        {
            try
            {
                Repository<Person> personRepo = new Repository<Person>(Repository.BaseContext());
                Person person = personRepo.Get().Where(x => x.Id == model.Person).FirstOrDefault();
                if (person != null)
                {
                    Account account = Parser.Create(model, Repository.BaseContext());
                    Repository.Insert(account);
                    return Ok(Factory.Create(account));
                }
                else
                    return BadRequest("There is no such person in the database");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(int id, AccountModel model)
        {
            try
            {
                Account account = Repository.Get(id);
                if (account == null)
                {
                    return NotFound();
                }
                else
                {
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), account.Id);
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Account account = Repository.Get(id);
                if (account == null)
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
                return BadRequest(ex.Message);
            }
        }
    }
}