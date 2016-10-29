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
    public class LoginController : BaseController<Person>
    {
        public LoginController(Repository<Person> depo) : base(depo) { }

        public IHttpActionResult Post (LoginModel model)
        {
            bool isMember = false;
            var allPeople = Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
            foreach(var person in allPeople)
            {
                if(model.Email == person.Email && model.Password == person.Password)
                {
                    isMember = true;
                }
            }
            if (isMember)
                return Ok();
            else
                return BadRequest();
        }
    }
}