using System.Collections.Generic;

namespace Yalta.Models
{
  public class PreferredPeriod
  {
    public long Id { get; set; }
    public int Lower { get; set; }
    public int Upper { get; set; }

    public long ProfilId { get; set; }
    public Profil Profil { get; set; }

    public ICollection<Area> Areas { get; set; }
  }
}
