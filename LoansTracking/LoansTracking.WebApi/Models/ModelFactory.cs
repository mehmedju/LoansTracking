using LoansTracking.DB;
using LoansTracking.DB.DataAccess;
using LoansTracking.DB.Entities;
using System;
using System.Linq;
using System.Text;

namespace LoansTracking.WebApi.Models
{
    public class ModelFactory
    {
        public LoanModel Create(Loan entity)
        {
            AppContext context = new AppContext();
            var LoanModel = new LoanModel()
            {
                Id = entity.Id,
                PersonLoanedTo = entity.PersonLoanedTo.Id,
                PersonLoanedFrom = entity.PersonLoanedFrom.Id,
                PersonLoanedToName = entity.PersonLoanedTo.FirstName,
                PersonLoanedToSurname = entity.PersonLoanedTo.LastName,
                PersonLoanedFromName = entity.PersonLoanedFrom.FirstName,
                PersonLoanedFromSurname = entity.PersonLoanedFrom.LastName,
                Amount = entity.Amount,
                DueDate = entity.DueDate,
                PaidOff = entity.PaidOff,
                Status = entity.Amount - entity.Payments.Select(x => x.AmountPaid).DefaultIfEmpty(entity.Amount).Sum()               
            };
            foreach(var payment in entity.Payments)
            {
                LoanModel.Payments.Add(new PaymentModel()
                {
                    AmountPaid = payment.AmountPaid,
                    Date = payment.Date,
                    Id = payment.Id,
                    PaidBy =entity.PersonLoanedTo.FirstName,
                    PaidById = entity.PersonLoanedTo.Id
                });
            }
            return LoanModel;         
        }

        public PaymentModel Create(Payment entity)
        {
            return new PaymentModel()
            {
                Id = entity.Id,
                AmountPaid = entity.AmountPaid,
                Date = entity.Date,
                PaidBy = entity.Loan.PersonLoanedTo.FirstName,
                PaidById = entity.Loan.PersonLoanedTo.Id
            };
        }

        public PersonModel Create(Person entity)
        {
            var base64Pass = Convert.FromBase64String(entity.Password);
            string realPass = Encoding.UTF8.GetString(base64Pass);
            return new PersonModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth,
                Gender = entity.Gender,
                MobileNumber = entity.MobileNumber,
                Address = entity.Address,
                Location = entity.Location,
                Company = entity.Company,
                Occupation = entity.Occupation,
                Email = entity.Email,
                Password = realPass
            };
        }

        public NoteModel Create(Note entity)
        {
            return new NoteModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Text = entity.Text
            };
        }
    }
}