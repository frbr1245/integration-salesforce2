using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Validation;

namespace Integration.Salesforce.Library.Models
{
    public class EMail
    {
        [Required]
        [EMailValidation(ErrorMessage = "{0} invalid email input")]
        public string cEMail { get; set; }

        public override string ToString()
        {
            return $"EMAIL{{EMail:{cEMail};}}";
        }
    }
}