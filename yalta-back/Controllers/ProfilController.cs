using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfilDTO>> GetOne(long id)
    {
      return await _profil.GetOne(id);
    }

    [HttpPost]
    public async Task<ActionResult<ProfilDTO>> Post(Profil Profil)
    {
      await _profil.Add(Profil);
      return CreatedAtAction(nameof(GetOne), new { id = Profil.Id }, Profil);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, ProfilUpdateDTO Profil)
    {
      await _profil.Update(Profil);
      return NoContent();
    }

  }
}
