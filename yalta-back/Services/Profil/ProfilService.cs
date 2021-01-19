using System.Collections.Generic;
using System.Threading.Tasks;
using Yalta.Models;
using Yalta.Models.DTO;
using AutoMapper;
using Yalta.Utils;
using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Yalta.Services
{
  public class ProfilService : IProfilService
  {
    private readonly YaltaContext _context;
    private readonly IPreferredPeriodService _preferredPeriodService;
    private readonly IMapper _mapper;

    public ProfilService(YaltaContext context, IMapper mapper, IPreferredPeriodService preferredPeriodService)
    {
      _context = context;
      _mapper = mapper;
      _preferredPeriodService = preferredPeriodService;
    }

    public async Task<IEnumerable<ProfilDTO>> GetAll()
    {
      return _mapper.Map<IEnumerable<ProfilDTO>>(await _context.Profil.Include(x => x.User).Include(x => x.LovedPersonalities).Include(x => x.HatedPersonalities).Include(x => x.PreferredPeriods).ThenInclude(x => x.Areas).ToListAsync());
    }

    public async Task<ProfilDTO> GetOne(long id)
    {
      return _mapper.Map<ProfilDTO>(await _context.Profil.Include(x => x.User).Include(x => x.PreferredPeriods).ThenInclude(x => x.Areas).FirstOrDefaultAsync(x => x.Id == id));
    }

    public async Task Add(Profil Profil)
    {
      _context.Profil.Add(Profil);
      await _context.SaveChangesAsync();
    }

    // TODO transac?
    public async Task Update(ProfilUpdateDTO Profil)
    {
      Profil profilMapper = _mapper.Map<Profil>(Profil);
      // We don't want to update the preferred periods by this way
      profilMapper.PreferredPeriods = null;

      // TODO verify that we don't have null in middle of the "list"
      profilMapper.HatedPersonalities.Id = profilMapper.Id;
      profilMapper.LovedPersonalities.Id = profilMapper.Id;

      _context.Profil.Update(profilMapper);
      await _context.SaveChangesAsync();

      // now we check for the preferred periods linked
      await _preferredPeriodService.UpdateForProfil(_mapper.Map<List<PreferredPeriod>>(Profil.PreferredPeriods), Profil.Id);
    }

  }
}