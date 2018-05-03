using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Salesforce.Service.Controllers
{
  [Route("api/[controller]")]
  public class ApartmentController : Controller {
    [HttpGet]
    public IEnumerable<Apartment> Get()
    {
      //TODO: return salesforce data
      return new List<Apartment>();
    }
  }
}
//TODO: delete this and use actual class
public class Apartment {
}