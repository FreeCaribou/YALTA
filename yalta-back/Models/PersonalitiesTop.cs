using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yalta.Models
{
  public class PersonalitiesTop
  {
    [ForeignKey("Profil")]
    public long Id { get; set; }
    public string First { get; set; }
    public string Second { get; set; }
    public string Third { get; set; }
    public string Fourth { get; set; }
    public string Fifth { get; set; }

    public virtual Profil Profil { get; set; }
  }
}
