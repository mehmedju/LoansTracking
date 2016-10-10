using System;

namespace LoansTracking.WebApi.Models
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