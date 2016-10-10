using LoansDbs.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansDbs
{
    public class AppContext: DbContext
    {
        public AppContext() : base("LoansContext") { }

        public DbSet<Loan> Loans { get; set; }
    }
}
