using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Yalta.Models;

[ApiController]
[Route("[controller]")]
public class ErrorController : ControllerBase
{

  [Route("error")]
  public IActionResult Error() => Problem();

  [Route("route")]
  public IActionResult ErrorRoute()
  {
    Console.WriteLine("haha ifff");
    throw new HttpResponseException(404, "Bad route");
  }

}