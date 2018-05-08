using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Integration.Salesforce.Library.Abstract;
using Integration.Salesforce.Library.Validation;
using Newtonsoft.Json.Linq;

namespace Integration.Salesforce.Library.Models
{
    public class HousingComplex : AModel
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
            var unitListString = $"UNITS{{";
            var returnString = $"COMPLEX{{ComplexName:{HousingComplexName};TransitOptions:{TransitOptions};}}";
            returnString += HousingContact.ToString();
            returnString += Location.ToString();
            foreach (var unit in HousingUnits)
            {
                unitListString += unit.ToString();
            }
            unitListString += "}}";

            return returnString;
        }

        public override void MapJsonToModel(JObject jsonObject)
        {

        }
    }
}