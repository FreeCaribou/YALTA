using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yalta.Models;
using Yalta.Models.DTO;

namespace Yalta.Services
{
  public class PreferredPeriodService : IPreferredPeriodService
  {
    private readonly YaltaContext _context;
    private readonly IMapper _mapper;

    public PreferredPeriodService(YaltaContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task UpdateForProfil(List<PreferredPeriod> PreferredPeriods, long profilId)
    {
      List<PreferredPeriod> actualPreferredPeriods = await _context.PreferredPeriod.Where(x => x.Profil.Id == profilId).ToListAsync();
      // TODO verify before if it is the same list
      // Have tried but lost my hair with that

      _context.PreferredPeriod.RemoveRange(actualPreferredPeriods);
      _context.SaveChanges();

      PreferredPeriods.ForEach(e =>
      {
        e.ProfilId = profilId;
        System.Console.WriteLine(e.Lower);
        PreferredPeriod npp = new PreferredPeriod { Lower = e.Lower, Upper = e.Upper, ProfilId = e.ProfilId, Areas = new List<Area>() };
        e.Areas.ToList().ForEach(i =>
        {
          Area na = _context.Area.Find(i.Id);
          if(na != null)
          {
            npp.Areas.Add(_context.Area.Find(i.Id));
          }
        });
        _context.PreferredPeriod.Add(npp);
        _context.SaveChanges();
      });

    }

    public async Task<IEnumerable<PreferredPeriod>> GetAll()
    {
      return await _context.PreferredPeriod.ToListAsync();
    }
  }
}
