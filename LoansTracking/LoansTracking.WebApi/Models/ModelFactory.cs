using LoansTracking.DB;
using LoansTracking.DB.DataAccess;
using LoansTracking.DB.Entities;
using System.Linq;

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
                Person = entity.Person.Id,
                Name = entity.Person.FirstName,
                Surname = entity.Person.LastName,
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
                    PaidBy =entity.Person.FirstName,
                    PaidById = entity.Person.Id
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
                PaidBy = entity.Loan.Person.FirstName,
                PaidById = entity.Loan.Person.Id
            };
        }

        public PersonModel Create(Person entity)
        {
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
                Email = entity.Email
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
        public AccountModel Create(Account entity)
        {
            return new AccountModel()
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password,
                CreationDate = entity.CreationDate,
                Person = entity.Person.Id
            };
        }
    }
}