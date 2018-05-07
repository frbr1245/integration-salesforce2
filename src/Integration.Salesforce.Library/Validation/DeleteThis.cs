using System;
using System.ComponentModel.DataAnnotations;

namespace Integration.Salesforce.Library.Validation
{
  [AttributeUsage(AttributeTargets.Property | 
    AttributeTargets.Field, AllowMultiple = false)]
  sealed public class BoolValidation : ValidationAttribute
  {
    //TODO: implement
    public bool IsValid(string value)
    {
      return true;
    }
  }
}

namespace Integration.Salesforce.Library.Validation
{
  [AttributeUsage(AttributeTargets.Property | 
    AttributeTargets.Field, AllowMultiple = false)]
  sealed public class PhoneValidation : ValidationAttribute
  {
    //TODO: implement
    public bool IsValid(string value)
    {
      return true;
    }
  }
}