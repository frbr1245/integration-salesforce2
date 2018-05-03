using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Abstract;
using Integration.Salesforce.Library.Validation;

namespace Integration.Salesforce.Library.Models
{
    public abstract class Address : AbstractAddress
    {
      [Required]
      [StringValidation(ErrorMessage = "{0} invalid string input")]
      public override string StreetAddress { get; set; }

      [Required]
      [StringValidation(ErrorMessage = "{0} invalid string input")]
      public override string City { get; set; }

      [Required]
      [MaxLength(2)]
      [StringValidation(ErrorMessage = "{0} invalid string input")]
      public string State { get; set; }

      [Required]
      [NumberValidation(ErrorMessage = "{0} invalid number input")]
      public override int Zip { get; set; }

      public override string ToString()
      {
        return $"{StreetAddress}, {City}, {State}, {Zip}";
      }
    }
}