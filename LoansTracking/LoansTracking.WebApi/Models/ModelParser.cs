using LoansDbs;
using LoansDbs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansTrackingApi.Models
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