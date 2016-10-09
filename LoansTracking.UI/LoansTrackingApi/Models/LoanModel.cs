using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansTrackingApi.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
}