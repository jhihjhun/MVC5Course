using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels.Client
{
    public class ClientReadViewModel
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<double> CreditRating { get; set; }
        public string XCode { get; set; }
        public Nullable<int> OccupationId { get; set; }
        public string TelephoneNumber { get; set; }
    }
}