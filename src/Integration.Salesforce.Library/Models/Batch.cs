using System;
using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Abstracts;
using Integration.Salesforce.Library.Validation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Integration.Salesforce.Library.Models
{
  public class Batch : AModel
  {
    [Required]
    [StringValidation(ErrorMessage = "{0} invalid string inputinvalid input")]
    public string Name { get; set; }

    [Required]
    [StringValidation(ErrorMessage = "{0} invalid string input")]
    public string SkillType { get; set; }
    
    [Required]
    [DateValidation(ErrorMessage = "{0} invalid DateTime input")]
    public DateTime StartDate { get; set; }

    [Required]
    [DateValidation(ErrorMessage = "{0} invalid DateTime input")]
    public DateTime EndDate { get; set; }

    [Required]
    public Person Trainer { get; set; }

    [Required]
    public Address Location {get; set;}
    
    public override string ToString()
    {
      return $"{Name}, {SkillType}, {StartDate.ToString()}, {EndDate.ToString()}, {Trainer.ToString()}, {Location.ToString()}";
    }
  }
}