using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yalta.Models.DTO
{
  public class PreferredPeriodDTO
  {
    public long Id { get; set; }
    public int Lower { get; set; }
    public int Upper { get; set; }
  }
}
