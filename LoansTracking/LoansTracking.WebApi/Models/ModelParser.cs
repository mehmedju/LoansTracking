using LoansTracking.DB;
using LoansTracking.DB.Entities;

namespace LoansTracking.WebApi.Models
{
    public class ModelParser
    {
        public Loan Create(LoanModel model, AppContext context)
        {
            return new Loan()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Amount = model.Amount,
                DueDate = model.DueDate
            };
        }
    }
}