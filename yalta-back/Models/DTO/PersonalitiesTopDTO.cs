using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yalta.Models.DTO
{
  public class PersonalitiesTopDTO
  {
    public string First { get; set; }
    public string Second { get; set; }
    public string Third { get; set; }
    public string Fourth { get; set; }
    public string Fifth { get; set; }
  }

  public class PersonalitiesTopPostDTO : PersonalitiesTopDTO
  {

  }
}
