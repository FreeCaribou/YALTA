namespace Yalta.Models
{
  public class PreferredPeriod
  {
    public long Id { get; set; }
    public int Lower { get; set; }
    public int Upper { get; set; }
    public Profil Profil { get; set; }
  }
}
