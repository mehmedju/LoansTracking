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

        public Note Create(NoteModel model, AppContext context)
        {
            return new Note()
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text
            };
        }
    }
}