using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansTracking.WebApi.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
    }
}