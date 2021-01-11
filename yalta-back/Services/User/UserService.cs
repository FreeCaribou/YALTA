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

    public async Task Registration(UserSignUpDTO user)
    {
      // TODO verify doublon
      User userMapper = _mapper.Map<User>(user);
      userMapper.CreatedAt = DateTime.Now;
      userMapper.Profil.PreferredPeriods = new List<PreferredPeriod>() { new PreferredPeriod() { Lower = -50, Upper = DateTime.Now.Year } };
      userMapper.Password = passwordHasher.Hash(userMapper.Password);
      _context.User.Add(userMapper);
      await _context.SaveChangesAsync();
    }
  }
}