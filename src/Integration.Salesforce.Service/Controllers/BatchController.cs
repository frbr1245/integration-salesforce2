using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Salesforce.Service.Controllers
{
  [Route("api/[controller]")]
  public class BatchController : Controller {
    [HttpGet]
    public IEnumerable<Batch> Get()
    {
      //TODO: return salesforce data
      return new List<Batch>();
    }
  }
}
//TODO: delete this and use actual class
public class Batch {
}