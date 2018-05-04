using System;
using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Validation;

namespace Integration.Salesforce.Library.Models
{
  public class Person
  {
    [Required]
    [StringValidation(ErrorMessage = "{0} invalid string input")]
    public string FirstName { get; set; }

    [Required]
    [StringValidation(ErrorMessage = "{0} invalid string input")]
    public string LastName { get; set; }

    [Required]
    [PhoneValidation(ErrorMessage = "{0} invalid phone number input")]
    public string Phone { get; set; }

    [Required]
    [StringValidation(ErrorMessage = "{0} invalid string input")]
    public string Role { get; set; }

    [Required]
    [BoolValidation(ErrorMessage = "{0} invalid bool input")]
    public bool HasCar { get; set; }

    [Required]
    public Address Address { get; set; }

    [Required]
    public EMail EMail { get; set; }

    [Required]
    public Batch Batch { get; set; }

    public override string ToString()
    {
      return $"{FirstName} {LastName}, {Phone}, {Role}, {HasCar}, {Address}, {EMail}, {Batch}";
    }
  }
}