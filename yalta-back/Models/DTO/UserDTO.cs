using System;
using System.ComponentModel.DataAnnotations;

namespace Yalta.Models.DTO
{
  public class UserSimpleDTO
  {
    public long Id { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class UserWithoutInfoDTO
  {
    public long Id { get; set; }
  }

  public class UserSignUpDTO
  {
    // TODO email validator
    [Required(ErrorMessage = "You must have an email.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "You must have a password.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "You must have a begin profil")]
    public ProfilSignUpForUserDTO Profil { get; set; }
  }
}