using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yalta.Models;
using Yalta.Models.DTO;

namespace Yalta.Services
{
  public interface IPreferredPeriodService
  {
    Task UpdateForProfil(List<PreferredPeriod> PreferredPeriods, long profilId);
    Task<IEnumerable<PreferredPeriod>> GetAll();
  }
}
