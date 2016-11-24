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
        public int PersonLoanedTo { get; set; }
        public int PersonLoanedFrom { get; set; }
        public string PersonLoanedToName { get; set; }
        public string PersonLoanedToSurname { get; set; }
        public string PersonLoanedFromName { get; set; }
        public string PersonLoanedFromSurname { get; set; }
        public double Amount { get; set; }
        public double Status { get; set; }
        public bool PaidOff { get; set; }
        public DateTime DueDate { get; set; }

        public IList<PaymentModel> Payments { get; set; }
    }
}