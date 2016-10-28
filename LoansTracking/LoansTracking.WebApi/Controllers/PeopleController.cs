using LoansTracking.DB.DataAccess;
using LoansTracking.DB.Entities;
using LoansTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace LoansTracking.WebApi.Controllers
{
    public class PeopleController : BaseController<Person>
    {
        public PeopleController(Repository<Person> depo) : base(depo) { }

        public IHttpActionResult GetByID(int id)
        {
            try
            {
                Person person = Repository.Get(id);
                if (person == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Factory.Create(person));
                }
            }
            catch (Exception ex)
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

        public IHttpActionResult Post(PersonModel model)
        {
            try
            {
                var passBytes = Encoding.UTF8.GetBytes(model.Password);
                string encodedPass = Convert.ToBase64String(passBytes);
                model.Password = encodedPass;
                Person person = Parser.Create(model, Repository.BaseContext());
                Repository.Insert(person);
                var newPerson = Repository.Get().OrderByDescending(x => x.Id).FirstOrDefault();
                return Ok(Factory.Create(newPerson));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Put(int id, PersonModel model)
        {
            try
            {
                Person person = Repository.Get(id);
                if (person == null)
                {
                    return NotFound();
                }
                else
                {
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), person.Id);
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
                Person person = Repository.Get(id);
                if (person == null)
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
