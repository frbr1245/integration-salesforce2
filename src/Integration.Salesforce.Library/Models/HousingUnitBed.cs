using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Validation;

namespace Integration.Salesforce.Library.Models
{
    public class HousingUnitBed
    {
      [Required]
      public Person Contact { get; set; }
      [Required]
      public HousingComplex HousingComplex {get; set;}
      [Required]
      public HousingUnit HousingUnit {get; set;}
      [Required]
      [StringValidation]
      public string HousingBedName { get; set; }
      [Required]
      [StringValidation]
      public string OccupancyStatus {get; set;}
      [Required]
      [DateValidation]
      public DateTime MoveInDate { get; set; }
      [Required]
      [DateValidation]
      public DateTime MoveOutDate { get; set; }
      [Required]
      [StringValidation]
      public string HousingKey { get; set; }
      [Required]
      [StringValidation]
      public string HousingFob { get; set; }

      public override string ToString()
      {
        return $"{Contact.ToString()}, {HousingComplex.ToString()}, {HousingUnit.ToString()}, {HousingBedName}, {OccupancyStatus}, {MoveInDate}, {MoveOutDate}, {HousingKey}, {HousingFob}";
      }
    }
}