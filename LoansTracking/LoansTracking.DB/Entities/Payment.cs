using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansTracking.DB.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double AmountPaid { get; set; }

        public virtual Loan Loan { get; set; }
    }
}
