using System;

namespace Yalta.Models
{
  public class User
  {
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Profil Profil { get; set; }
  }
}