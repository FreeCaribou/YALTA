using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
      context.Database.EnsureDeleted();
      context.Database.Migrate();

      //context.User.RemoveRange(context.Set<User>());
      //context.PreferredPeriod.RemoveRange(context.Set<PreferredPeriod>());
      //context.Profil.RemoveRange(context.Set<Profil>());
      //context.SaveChanges();

      // The area data
      List<Area> areas = new List<Area>
      {
        new Area()
        {
          Code="1",
          Label="Africa"
        },
        new Area()
        {
          Code="2",
          Label="America"
        },
        new Area()
        {
          Code="3",
          Label="Asia"
        },
        new Area()
        {
          Code="4",
          Label="Europe"
        },
        new Area()
        {
          Code="5",
          Label="Oceania"
        }
      };
      context.Area.AddRange(areas);
      context.SaveChanges();

      List<Area> areasForNewProfil = new List<Area>();
      
      areasForNewProfil.Add(context.Area.Where(x => x.Code == "1").FirstOrDefault());
      areasForNewProfil.Add(context.Area.Where(x => x.Code == "2").FirstOrDefault());

      // fake one user
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
        LovedPersonalities = new LovedPersonalities()
        {
          First = "Rosa Luxemburg",
          Second = "Louise Michel"
        },
        HatedPersonalities = new HatedPersonalities()
        {
          First = "Churchill",
          Second = "de Gaulle",
          Third = "Staline"
        }
      };
      context.Profil.Add(samyProfil);
      context.SaveChanges();
      PreferredPeriod pf1 = new PreferredPeriod()
      {
        Lower = -50,
        Upper = 1250,
        Profil = samyProfil,
        Areas = areasForNewProfil
      };
      context.PreferredPeriod.Add(pf1);
      context.SaveChanges();


      Console.WriteLine("DB init finish");
    }

  }
}