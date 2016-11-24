using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansTracking.WebApi.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double AmountPaid { get; set; }

        public string PaidBy { get; set; }
        public int PaidById { get; set; }
        public int LoanId;
    }
}