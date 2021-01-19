using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yalta.Models.DTO
{
  public class AreaDTO
  {
    public long Id { get; set; }
    public string Code { get; set; }
    public string Label { get; set; }
  }

  public class AreaPutDTO
  {
    public long Id { get; set; }
    public string Code { get; set; }
    public string Label { get; set; }
  }
}
