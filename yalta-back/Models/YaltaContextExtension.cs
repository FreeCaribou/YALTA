using Microsoft.EntityFrameworkCore;
using System;
using Yalta.Utils;

namespace Yalta.Models
{
  public static class YaltaContextExtension
  {

    public static void EnsureSeedDataForContext(this YaltaContext context)
    {
      Console.WriteLine("Hello World");

      PasswordHasher passwordHasher = new PasswordHasher();

      // TODO see all with dev or prod deploiement
      context.User.RemoveRange(context.Set<User>());
      context.Profil.RemoveRange(context.Set<Profil>());
      context.SaveChanges();

      User samy = new User()
      {
        Name = "Samy Gnu",
        Email = "samy@gnu.no",
        Password = "c@rIBoU"
      };

      samy.Password = passwordHasher.Hash(samy.Password);

      context.User.Add(samy);
      context.SaveChanges();

      Profil samyProfil = new Profil()
      {
        BirthdayDate = new DateTime(1993, 12, 24),
        Gender = "m",
        User = samy
      };

      context.Profil.Add(samyProfil);
      context.SaveChanges();

      Console.WriteLine("DB init finish");
    }

  }
}