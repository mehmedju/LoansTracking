using LoansDbs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansTrackingApi.Models
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
    }
}