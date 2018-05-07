using System;
using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Validation;

namespace Integration.Salesforce.Library.Models
{
  public class Batch
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
      string returnString = $"BATCH{{Name:{Name};SkillType:{SkillType};StartDate:{StartDate.Date.ToString("yyyy-dd-MM")};EndDate:{EndDate.Date.ToString("yyyy-dd-MM")}}}";
      returnString += Trainer.ToString();
      returnString += Location.ToString();
      return returnString;
    }
  }
}