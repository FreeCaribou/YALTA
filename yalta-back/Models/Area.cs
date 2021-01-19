using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yalta.Models
{
  public class Area : CodeLabel
  {
    public virtual ICollection<PreferredPeriod> PreferredPeriods { get; set; }
  }
}
