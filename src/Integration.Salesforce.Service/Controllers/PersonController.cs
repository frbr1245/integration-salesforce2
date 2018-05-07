using System.Collections.Generic;
using Integration.Salesforce.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Salesforce.Service.Controllers
{
  [Route("api/[controller]")]
  public class PersonController : Controller {
    [HttpGet]
    public IEnumerable<Person> Get()
    {
      //TODO: return salesforce data
      return new List<Person>();
    }
  }
}