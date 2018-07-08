using MVC5Course.Helpers.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels.Client
{
    public class ClientUpdateViewModel : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Longitude.HasValue != this.Latitude.HasValue)
            {
                yield return new ValidationResult("經緯度欄位必須一起設定", new string[] { "Longitude", "Latitude" });
            }
        }

        public int ClientId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
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

        [Required]
        [IdNumberCheck]
        public string IdNumber { get; set; }


    }
}