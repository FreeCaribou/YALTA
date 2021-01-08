using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Yalta.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ApiController : ControllerBase
  {

    public ApiController()
    {

    }

    [HttpGet]
    public string Get()
    {
      return Environment.GetEnvironmentVariable("Test");
    }
  }
}
