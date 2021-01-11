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
      context.PreferredPeriod.RemoveRange(context.Set<PreferredPeriod>());
      context.Profil.RemoveRange(context.Set<Profil>());
      context.SaveChanges();

      User samy = new User()
      {
        Email = "samy@gnu.no",
        Password = "c@rIBoU",
        CreatedAt = DateTime.Now
      };

      samy.Password = passwordHasher.Hash(samy.Password);

      context.User.Add(samy);
      context.SaveChanges();

      Profil samyProfil = new Profil()
      {
        Name = "Samy Gnu",
        BirthdayDate = new DateTime(1993, 12, 24),
        Gender = "m",
        User = samy,
      };
      context.Profil.Add(samyProfil);
      context.SaveChanges();

      PreferredPeriod pf1 = new PreferredPeriod()
      {
        Lower = -50,
        Upper = 1250,
        Profil = samyProfil
      };
      context.PreferredPeriod.Add(pf1);
      context.SaveChanges();

      Console.WriteLine("DB init finish");
    }

  }
}