﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yalta.Middleware
{
  // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
  public class ErrorMiddleware
  {
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
      System.Console.WriteLine("Hello middleware");
      System.Console.WriteLine(httpContext.Response.StatusCode);
      return _next(httpContext);
    }
  }

  // Extension method used to add the middleware to the HTTP request pipeline.
  public static class ErrorMiddlewareExtensions
  {
    public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<ErrorMiddleware>();
    }
  }
}
