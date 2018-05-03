using System.Collections.Generic;
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
//TODO: delete this and use actual class
public class Person {
}