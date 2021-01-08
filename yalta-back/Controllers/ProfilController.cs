using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yalta.Services;
using Yalta.Models;
using Yalta.Models.DTO;


namespace Yalta.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProfilController : ControllerBase
  {
    private readonly IProfilService _profil;

    public ProfilController(IProfilService profil)
    {
      _profil = profil;
    }

    [HttpGet]
     public async Task<ActionResult<IEnumerable<ProfilDTO>>> GetAll()
    {
      return Ok(await _profil.GetAll());
    }

  }
}
