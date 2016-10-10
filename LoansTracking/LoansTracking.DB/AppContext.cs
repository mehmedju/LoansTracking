using System.Data.Entity;
using LoansTracking.DB.Entities;

namespace LoansTracking.DB
{
    public class AppContext: DbContext
    {
        public AppContext() : base("LoansContext") { }

        public DbSet<Loan> Loans { get; set; }
    }
}
