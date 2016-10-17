using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansTracking.WebApi.Models
{
    public class TotalStatisticsModel
    {
        public double TotalActive { get; set; }
        public double TotalPaidOff { get; set; }
    }
}