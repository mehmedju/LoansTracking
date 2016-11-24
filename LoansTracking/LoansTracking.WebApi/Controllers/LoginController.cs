using LoansTracking.DB.DataAccess;
using LoansTracking.DB.Entities;
using LoansTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace LoansTracking.WebApi.Controllers
{
    public class LoginController : BaseController<Person>
    {
        public LoginController(Repository<Person> depo) : base(depo) { }

        public IHttpActionResult Post (LoginModel model)
        {
            bool isMember = false;
            int id = 0;
            var allPeople = Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
            foreach (var person in allPeople)
            {
                if (model.Email == person.Email && model.Password == person.Password)
                {
                    isMember = true;
                    id = person.Id;
                }
            }
            if (isMember)
                return Ok(id);
            else
                return BadRequest();
        }
    }
}