using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansTracking.DB.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
}
