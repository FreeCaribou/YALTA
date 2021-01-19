using Microsoft.EntityFrameworkCore;

namespace Yalta.Models
{
  public class YaltaContext : DbContext
  {
    public YaltaContext(DbContextOptions<YaltaContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<Profil> Profil { get; set; }
    public DbSet<LovedPersonalities> LovedPersonalities { get; set; }
    public DbSet<HatedPersonalities> HatedPersonalities { get; set; }
    public DbSet<PreferredPeriod> PreferredPeriod { get; set; }
    public DbSet<Area> Area { get; set; }
  }
}