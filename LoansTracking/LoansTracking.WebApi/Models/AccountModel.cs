using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansTracking.WebApi.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public int Person { get; set; }
    }
}