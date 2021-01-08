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
    private readonly IMapper _mapper;

    public ProfilService(YaltaContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ProfilDTO>> GetAll()
    {
      return _mapper.Map<IEnumerable<ProfilDTO>>(await _context.Profil.Include(x => x.User).ToListAsync());
    }

  }
}