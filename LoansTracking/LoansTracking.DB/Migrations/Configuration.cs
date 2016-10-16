namespace LoansTracking.DB.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppContext context)
        {
            //  When you do your first update of the Db uncomment the code below

            //context.People.AddOrUpdate(
            //  p => p.Id,
            //  new Person { FirstName = "John", LastName = "Doe" },
            //  new Person { FirstName = "Johane", LastName = "Doe" }
            //);
            //context.SaveChanges();
            //context.Loans.AddOrUpdate(
            // l => l.Id,
            // new Loan { Amount = 500, DueDate = DateTime.Now.AddMonths(6), PaidOff = true, Person = context.People.Find(1) },
            // new Loan { Amount = 2000, DueDate = DateTime.Now.AddMonths(8), PaidOff = false, Person = context.People.Find(2) }
            //);
            //context.SaveChanges();
            //context.Payements.AddOrUpdate(
            //x => x.Id,
            // new Payment { AmountPaid = 100, Date = DateTime.Now, Loan = context.Loans.Find(1) },
            // new Payment { AmountPaid = 100, Date = DateTime.Now, Loan = context.Loans.Find(1) },
            // new Payment { AmountPaid = 100, Date = DateTime.Now, Loan = context.Loans.Find(1) },
            // new Payment { AmountPaid = 100, Date = DateTime.Now, Loan = context.Loans.Find(1) },
            // new Payment { AmountPaid = 70, Date = DateTime.Now, Loan = context.Loans.Find(1) },
            // new Payment { AmountPaid = 30, Date = DateTime.Now, Loan = context.Loans.Find(1) },
            // new Payment { AmountPaid = 150, Date = DateTime.Now, Loan = context.Loans.Find(2) },
            // new Payment { AmountPaid = 100, Date = DateTime.Now, Loan = context.Loans.Find(2) },
            // new Payment { AmountPaid = 190, Date = DateTime.Now, Loan = context.Loans.Find(2) },
            // new Payment { AmountPaid = 300, Date = DateTime.Now, Loan = context.Loans.Find(2) },
            // new Payment { AmountPaid = 70, Date = DateTime.Now, Loan = context.Loans.Find(2) },
            // new Payment { AmountPaid = 30, Date = DateTime.Now, Loan = context.Loans.Find(2) },
            // new Payment { AmountPaid = 10, Date = DateTime.Now, Loan = context.Loans.Find(2) }
            //);

            //context.Notes.AddOrUpdate(
            // n => n.Id,
            // new Note { Text = "This is the first Note", Title = "First Note" },
            // new Note { Text = "And this is the second one", Title = "Second Note" },


        }
    }
}
