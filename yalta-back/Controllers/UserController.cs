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
  public class UserController : ControllerBase
  {
    private readonly IUserService _user;

    // TODO return a token
    public UserController(IUserService user)
    {
      _user = user;
    }

    [HttpPost("login")]
     public async Task<ActionResult<IEnumerable<UserSimpleDTO>>> Login(User user)
    {
      return Ok(await _user.Login(user));
    }

    [HttpPost("signup")]
    public async Task<ActionResult<UserSimpleDTO>> Registration(UserSignUpDTO user)
    {
      await _user.Registration(user);
      return CreatedAtAction(nameof(Login), user);
    }
  }
}
