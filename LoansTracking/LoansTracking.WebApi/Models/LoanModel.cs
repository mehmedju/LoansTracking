using System;
using System.Collections.Generic;

namespace LoansTracking.WebApi.Models
{
    public class LoanModel
    {
        public LoanModel()
        {
            Payments = new List<PaymentModel>();
        }
        public int Id { get; set; }
        public int Person { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Amount { get; set; }
        public double Status { get; set; }
        public bool PaidOff { get; set; }
        public DateTime DueDate { get; set; }

        public IList<PaymentModel> Payments { get; set; }
    }
}