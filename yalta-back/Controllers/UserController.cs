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
  public class UserController : ControllerBase
  {
    private readonly IUserService _user;

    public UserController(IUserService user)
    {
      _user = user;
    }

    [HttpGet("login")]
     public async Task<ActionResult<IEnumerable<UserSimpleDTO>>> Login(User user)
    {
      return Ok(await _user.Login(user));
    }

    [HttpPost("signup")]
    public async Task<ActionResult<UserSimpleDTO>> Registration(User user)
    {
      await _user.Registration(user);

      // maybe rework the return for the password
      return CreatedAtAction(nameof(Login), user);
    }
  }
}
