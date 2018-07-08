using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels.Client
{
    public class ClientReadViewModel
    {
        public SearchCondiction Condiction { get; set; }

        public List<ClientListItem> ClientList { get; set; }

        public class SearchCondiction
        {
            public string Keyword { get; set; }
        }

        public class ClientListItem
        {
            public int ClientId { get; set; }

            public string FirstName { get; set; }

            public string MiddleName { get; set; }

            public string LastName { get; set; }

            public string Gender { get; set; }

            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            public Nullable<System.DateTime> DateOfBirth { get; set; }

            public Nullable<double> CreditRating { get; set; }

            public string XCode { get; set; }

            public Nullable<int> OccupationId { get; set; }

            public string TelephoneNumber { get; set; }
        }


    }
}