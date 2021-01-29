using Microsoft.AspNetCore.Mvc.Filters;
using Yalta.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Yalta.Utils
{
  public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
  {
    public int Order { get; set; } = int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (context.Exception is HttpResponseException exception)
      {
        context.Result = new ObjectResult(exception.Errors)
        {
          StatusCode = exception.Status,
          Value = new HttpResponseException(exception.Status, exception.Errors.ToString())
        };
        context.ExceptionHandled = true;
      }
    }
  }
}
