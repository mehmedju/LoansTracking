using LoansTracking.DB;
using LoansTracking.DB.DataAccess;
using LoansTracking.DB.Entities;
using System;
using System.Linq;

namespace LoansTracking.WebApi.Models
{
    public class ModelParser
    {
        public Loan Create(LoanModel model, AppContext context)
        {
            return new Loan()
            {
                Id = model.Id,
                Person = context.People.Find(model.Person),
                Amount = model.Amount,
                DueDate = model.DueDate,
                PaidOff = model.PaidOff
            };
        }


        public Person Create(PersonModel model, AppContext context)
        {
            return new Person()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName= model.LastName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                MobileNumber = model.MobileNumber,
                Address = model.Address,
                Location = model.Location,
                Company = model.Company,
                Occupation = model.Occupation,
                Email = model.Email
            };
        }

        public Payment Create(PaymentModel model, AppContext context)
        {
            var payment = new Payment()
            {
                Id = model.Id,
                AmountPaid = model.AmountPaid,
                Date = model.Date,  
                
            };
            payment.Loan = new Repository<Loan>(context).Get().Where(x => x.Person.Id == model.PaidById).FirstOrDefault();
            return payment;
        }

        public Note Create(NoteModel model, AppContext context)
        {
            return new Note()
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text
            };
        }
        public Account Create(AccountModel model, AppContext context)
        {
            return new Account()
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                CreationDate = DateTime.Now,
                Person = context.People.Find(model.Person)
            };
        }
    }
}