using LoansTracking.DB.Entities;

namespace LoansTracking.WebApi.Models
{
    public class ModelFactory
    {
        public LoanModel Create(Loan entity)
        {
            return new LoanModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Amount = entity.Amount,
                DueDate = entity.DueDate
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