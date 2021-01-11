using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Yalta.Models.DTO
{
  public class ProfilDTO
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthdayDate { get; set; }
    public string Gender { get; set; }

    public List<PreferredPeriodDTO> PreferredPeriods { get; set; }

    public UserWithoutInfoDTO User { get; set; }

    public int Age { get; set; }
  }

  public class ProfilSignUpForUserDTO
  {
    [Required(ErrorMessage = "You must have a name.")]
    public string Name { get; set; }
    // TODO verify valid date
    [Required(ErrorMessage = "You must have a birthday.")]
    public DateTime BirthdayDate { get; set; }
  }

  public class ProfilUpdateDTO : ProfilSignUpForUserDTO
  {
    [Required(ErrorMessage = "You must have a gender.")]
    public string Gender { get; set; }

    [Required]
    public long Id { get; set; }
  }
}