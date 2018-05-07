using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Integration.Salesforce.Library.Models;

namespace Integration.Salesforce.Service.Controllers
{
  [Route("api/[controller]")]
  public class ApartmentController : Controller {
    [HttpGet]
    public IEnumerable<HousingComplex> Get()
    {
      //TODO: return salesforce data
      return new List<HousingComplex>();
    }
  }
}
