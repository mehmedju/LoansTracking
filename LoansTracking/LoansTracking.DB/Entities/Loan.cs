using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansTracking.DB.Entities
{
    public class Loan
    {
        public Loan()
        {
            Payments = new Collection<Payment>();
        }
        public int Id { get; set; }
        public bool PaidOff { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
    
}
