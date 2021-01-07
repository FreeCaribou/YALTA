using Microsoft.EntityFrameworkCore;
using System;


namespace Yalta.Models
{
  public static class YaltaContextExtension
  {

    public static void EnsureSeedDataForContext(this YaltaContext context)
    {
      Console.WriteLine("Hello World");

      context.User.RemoveRange(context.Set<User>());
      context.SaveChanges();

      User samy = new User()
      {
        Name = "Samy Gnu",
        Email = "samy@gnu.no",
        Password = "c@rIBoU"
      };

      context.User.Add(samy);
      context.SaveChanges();

      Console.WriteLine("DB init finish");
    }

  }
}