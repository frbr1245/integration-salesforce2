using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Validation;

namespace Integration.Salesforce.Library.Models
{
    public class HousingUnitBed
    {
        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ComplexName { get; set; }

        [Required]
        public int UnitNumber { get; set; }

        [Required]
        [StringValidation]
        public string HousingBedName { get; set; }

        //options: housing needed, housing assigned, moved in,
        //need to check out, moved out, cancelled
        [Required]
        [StringValidation]
        public string OccupancyStatus { get; set; }

        [Required]
        [DateValidation]
        public DateTime MoveInDate { get; set; }

        [Required]
        [DateValidation]
        public DateTime MoveOutDate { get; set; }

        //options: not needed, pending, issued, need to collect,
        //collected
        [Required]
        [StringValidation]
        public string HousingKey { get; set; }

        //options: not needed, pending, issued, need to collect,
        //collected
        [Required]
        [StringValidation]
        public string HousingFob { get; set; }

        public override string ToString()
        {
            var returnString = $"{ComplexName}, {UnitNumber}, {HousingBedName}, {ContactName}, {OccupancyStatus}, {MoveInDate.Date}, {MoveOutDate.Date}, {HousingKey}, {HousingFob}";

            return returnString;
        }
    }
}