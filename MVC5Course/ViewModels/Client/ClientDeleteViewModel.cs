using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels.Client
{
    public class ClientDeleteViewModel
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

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public Nullable<double> Longitude { get; set; }

        public Nullable<double> Latitude { get; set; }

        public string Notes { get; set; }

        public string IdNumber { get; set; }
    }
}