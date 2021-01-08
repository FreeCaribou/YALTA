using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yalta.Models
{
  public class Profil
  {
    [ForeignKey("User")]
    public long Id { get; set; }
    public DateTime BirthdayDate { get; set; }
    public string Gender { get; set; }

    public virtual User User { get; set; }
  }
}