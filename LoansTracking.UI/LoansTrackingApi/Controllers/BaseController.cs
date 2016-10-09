using LoansDbs.DataAccess;
using LoansTrackingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoansTrackingApi.Controllers
{
    public class BaseController<T> : ApiController where T : class
    {
        private Repository<T> depo;
        private ModelFactory fact;
        private ModelParser pars;

        public BaseController(Repository<T> _depo)
        {
            depo = _depo;
        }

        protected Repository<T> Repository
        {
            get { return depo; }
        }

        protected ModelFactory Factory
        {
            get
            {
                if (fact == null) fact = new ModelFactory();
                return fact;
            }
        }
        protected ModelParser Parser
        {
            get
            {
                if (pars == null) pars = new ModelParser();
                return pars;
            }
        }
    }
}
