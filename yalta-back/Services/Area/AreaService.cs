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
  public class AreaService : IAreaService
  {

    private readonly YaltaContext _context;
    private readonly IMapper _mapper;

    public AreaService(YaltaContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IEnumerable<AreaDTO>> GetAll()
    {
      return _mapper.Map<IEnumerable<AreaDTO>>(await _context.Area.ToListAsync());
    }
  }
}
