using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Validation;

namespace Integration.Salesforce.Library.Models
{
    public class HousingComplex
    {
      [Required]
      [StringValidation(ErrorMessage = "{0} invalid string input")]
      public string HousingComplexName { get; set; }
      [Required]
      public Address Location { get; set; }
      [Required]
      public Person HousingContact { get; set; }
      [Required]
      [StringValidation(ErrorMessage = "{0} invalid string input")]
      public string TransitOptions { get; set; }
      [Required]
      public List<HousingUnit> HousingUnits { get; set; }
      
      public override string ToString()
      {
        return $"{HousingComplexName}, {Location.ToString()}, {HousingContact.ToString()}, {TransitOptions}, {HousingUnits.ToString()}";
      }
    }
}