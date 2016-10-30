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
    public class StatisticsController : BaseController<Loan>
    {
        public StatisticsController(Repository<Loan> depo) : base(depo) { }

        [Route("api/statistics/total")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var totalModel = new TotalStatisticsModel();
                totalModel.TotalPaidOff = new Repository<Payment>(Repository.BaseContext()).Get().Select(x => x.AmountPaid).DefaultIfEmpty(0).Sum();
                var totalAmount = Repository.Get().Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                totalModel.TotalActive = totalAmount - totalModel.TotalPaidOff;
                return Ok(totalModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        [Route("api/statistics/paidoff")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var AllPaidOffLoans = Repository.Get().Where(x => x.PaidOff).ToList().Select(x => Factory.Create(x)).ToList();
                if (AllPaidOffLoans.Count != 0)
                {
                    return Ok(AllPaidOffLoans);
                }
                else
                {
                    return Ok("You don't have any paid off loans");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
