using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yalta.Models
{
  public class HttpResponseException : Exception
  {
    public HttpResponseException()
    {
    }

    public HttpResponseException(int Status, string Errors)
    {
      this.Status = Status;
      this.Errors = Errors;
    }

    public int Status { get; set; } = 500;

    public string Errors { get; set; } = "An error has occurred";
  }
}
