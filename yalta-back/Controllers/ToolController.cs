using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yalta.Models.DTO;
using Yalta.Services;

namespace Yalta.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ToolController : Controller
  {
    private readonly IAreaService _area;

    public ToolController(IAreaService area)
    {
      _area = area;
    }

    [HttpGet("areas")]
    public async Task<ActionResult<IEnumerable<AreaDTO>>> GetAll()
    {
      return Ok(await _area.GetAll());
    }
  }
}
