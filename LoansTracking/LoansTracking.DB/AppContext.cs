using LoansTracking.DB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansTracking.DB
{
    public class AppContext : DbContext
    {
        public AppContext() : base("LoansContext") { }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
