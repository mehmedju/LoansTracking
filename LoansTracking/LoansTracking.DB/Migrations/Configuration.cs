namespace LoansTracking.DB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppContext context)
        {
            context.People.AddOrUpdate(
                p => p.Id,
                new Person
                {
                    FirstName = "Admin",
                    LastName = "Administrator",
                    DateOfBirth = DateTime.Now,
                    Gender = "Male",
                    MobileNumber = "111/222-333",
                    Address = "Address 1",
                    Location = "Sarajevo",
                    Company = "Mistral",
                    Occupation = "Developer",
                    Email = "admin",
                    Password = "password"
                }
            );
            context.SaveChanges();
            var allLoans = context.Loans.ToList();
            if(allLoans != null)
            {
                foreach(var loan in allLoans)
                {
                    loan.Person = context.People.Where(x => x.Email == "admin").FirstOrDefault();
                    context.SaveChanges();
                }
            }
            var allNotes = context.Notes.ToList();
            if (allNotes != null)
            {
                foreach (var note in allNotes)
                {
                    note.Person = context.People.Where(x => x.Email == "admin").FirstOrDefault();
                    context.SaveChanges();
                }
            }
            //context.People.AddOrUpdate(
            //  p => p.Id,
            //  new Person
            //  {
            //      FirstName = "John",
            //      LastName = "Doe",
            //      DateOfBirth = DateTime.Now,
            //      Gender = "Male",
            //      MobileNumber = "061 456 789",
            //      Address = "Milana Preloga 12",
            //      Company = "Mistral",
            //      Location = "Sarajevo",
            //      Email = "johndoe@mail.com",
            //      Occupation = "Software developer"
            //  },
            // new Person
            // {
            //     FirstName = "Kevin",
            //     LastName = "Smith",
            //     DateOfBirth = DateTime.Now,
            //     Gender = "Male",
            //     MobileNumber = "061 589 111",
            //     Address = "Grbavicka 18",
            //     Company = "Mistral",
            //     Location = "Sarajevo",
            //     Email = "kevinsmith@mail.com",
            //     Occupation = "Software developer"
            // }
            //);
            //context.SaveChanges();
            //context.Loans.AddOrUpdate(
            // l => l.Id,
            // new Loan { Amount = 500, DueDate = DateTime.Now.AddMonths(6), PaidOff = true, Person = context.People.Find(1) },
            // new Loan { Amount = 2000, DueDate = DateTime.Now.AddMonths(8), PaidOff = false, Person = context.People.Find(2) }
            //);
            //context.SaveChanges();
            //context.Payments.AddOrUpdate(
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
            //    n => n.Id,
            //    new Note { Text = "This is the first Note", Title = "First Note" },
            //    new Note { Text = "And this is the second one", Title = "Second Note" });
        }
    }
}
