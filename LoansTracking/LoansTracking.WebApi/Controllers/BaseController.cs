using System.Web.Http;
using LoansTracking.DB.DataAccess;
using LoansTracking.WebApi.Models;

namespace LoansTracking.WebApi.Controllers
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
