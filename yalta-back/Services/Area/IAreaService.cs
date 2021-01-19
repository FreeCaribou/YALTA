using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yalta.Models;
using Yalta.Models.DTO;

namespace Yalta.Services
{
  public interface IAreaService
  {
    Task<IEnumerable<AreaDTO>> GetAll();
  }
}
