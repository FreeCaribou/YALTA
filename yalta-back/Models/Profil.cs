using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Yalta.Models
{
  public class Profil
  {
    [ForeignKey("User")]
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthdayDate { get; set; }
    public string Gender { get; set; }

    public virtual User User { get; set; }
    public virtual LovedPersonalities LovedPersonalities { get; set; }
    public virtual HatedPersonalities HatedPersonalities { get; set; }

    public List<PreferredPeriod> PreferredPeriods { get; set; }
  }
}