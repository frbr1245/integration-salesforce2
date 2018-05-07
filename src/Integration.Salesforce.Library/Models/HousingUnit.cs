using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Validation;

namespace Integration.Salesforce.Library.Models
{
    public class HousingUnit
    {
        [Required]
        [StringValidation(ErrorMessage = "{0} invalid string input")]
        public string ComplexName { get; set; }

        [Required]
        [NumberValidation(ErrorMessage = "{0} invalid number input")]
        public int UnitNumber { get; set; }

        [Required]
        [BoolValidation(ErrorMessage = "{0} invalid boolean input")]
        public bool InUse { get; set; }

        [Required]
        [DateValidation(ErrorMessage = "{0} invalid date input")]
        public DateTime LeaseStartDate { get; set; }

        [Required]
        [DateValidation(ErrorMessage = "{0} invalid date input")]
        public DateTime LeaseEndDate { get; set; }

        [Required]
        [StringValidation(ErrorMessage = "{0} invalid string input")]
        public string UnitGender { get; set; }

        [Required]
        [StringValidation(ErrorMessage = "{0} invalid string input")]
        public List<string> UnitAmenities { get; set; }

        [Required]
        public List<HousingUnitBed> NumberOfBeds { get; set; }
        public int AvailableBeds
        {
            get
            {
                var _availBeds = 6 - NumberOfBeds.Count;
                return _availBeds;
            }
        }

        public override string ToString()
        {
            var returnString = $"HOUSINGUNIT:UnitNumber:{UnitNumber};InUse:{InUse};LeaseStartDate:{LeaseStartDate.Date.ToString("yyyy-MM-dd")};LeaseEndDate:{LeaseEndDate.Date.ToString("yyyy-MM-dd")};UnitGender:{UnitGender};NumberOfBeds:{NumberOfBeds.Count};AvailableBeds:{AvailableBeds}";
            var _amenities = "";
            foreach (var amenities in UnitAmenities)
            {
                _amenities += $"{amenities}, ";
            }
            returnString += _amenities;

            return returnString;
        }
    }
}