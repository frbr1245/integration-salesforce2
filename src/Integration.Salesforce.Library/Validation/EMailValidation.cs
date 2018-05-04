using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Integration.Salesforce.Library.Validation
{
  [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
  public class EMailValidation : ValidationAttribute
  {
    public bool IsValid(string email)
    {
      var address = new System.Net.Mail.MailAddress(email);
      if (address.Address == email)
      {
        return true;
      }
      return false;
    }

    public override string FormatErrorMessage(string name)
    {
      return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
    }
  }
}