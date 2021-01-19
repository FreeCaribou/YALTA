using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yalta.Models.DTO
{
  public class PreferredPeriodDTO
  {
    public int Lower { get; set; }
    public int Upper { get; set; }
    public List<AreaDTO> Areas { get; set; }
  }

  public class PreferredPeriodPutDTO
  {
    public int Lower { get; set; }
    public int Upper { get; set; }
    public List<AreaPutDTO> Areas { get; set; }
  }

}
