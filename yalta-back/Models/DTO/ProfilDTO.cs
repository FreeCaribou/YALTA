using System;

namespace Yalta.Models.DTO
{
  public class ProfilDTO
  {
    public long Id { get; set; }
    public DateTime BirthdayDate { get; set; }
    public string Gender { get; set; }

    public UserWithoutInfoDTO User { get; set; }

    public int Age { get; set; }
    public string Name { get; set; }
  }
}