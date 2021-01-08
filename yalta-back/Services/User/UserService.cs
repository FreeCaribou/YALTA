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
  public class UserService : IUserService
  {
    private readonly YaltaContext _context;
    private readonly IMapper _mapper;
    private readonly PasswordHasher passwordHasher;

    public UserService(YaltaContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
      passwordHasher = new PasswordHasher();
    }

    public async Task<UserSimpleDTO> Login(User user)
    {
      User userLogged;
      try
      {
        userLogged = await _context.User.SingleAsync(x => x.Email == user.Email);
      }
      catch (Exception e)
      {
        throw new ArgumentException("You dont exist");
      }

      if (!passwordHasher.Check(userLogged.Password, user.Password).Verified)
      {
        Console.WriteLine("bad password");
        // TODO see how manage bad password
        // return NotFound();

        throw new ArgumentException("Bad password");
        // throw new HttpResponseException()
        // {
        //   Status = 404,
        //   Value = "Bad password"
        // };
      }

      var result = _mapper.Map<UserSimpleDTO>(userLogged);
      return result;
    }

    public async Task Registration(User user)
    {
      // TODO verify doublon
      user.Password = passwordHasher.Hash(user.Password);
      _context.User.Add(user);
      await _context.SaveChangesAsync();
    }
  }
}