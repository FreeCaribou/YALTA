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
using Newtonsoft.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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

    public async Task<TokenDTO> Login(User user)
    {
      User userLogged;
      try
      {
        userLogged = await _context.User.SingleAsync(x => x.Email == user.Email);
      }
      catch (Exception e)
      {
        throw new HttpResponseException(400, "You don't exist");
      }

      if (!passwordHasher.Check(userLogged.Password, user.Password).Verified)
      {
        throw new HttpResponseException(400, "Bad Password");
      }

      //string key = Environment.GetEnvironmentVariable("JWT_Token");
      string key = Environment.GetEnvironmentVariable("JWT_Token");
      var securityKey = new Microsoft
               .IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
      var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                           (securityKey, SecurityAlgorithms.HmacSha256Signature);
      var header = new JwtHeader(credentials);
      var payload = new JwtPayload
           {
               { "id", userLogged.Id },
               { "date", DateTime.Now },
           };
      var secToken = new JwtSecurityToken(header, payload);
      var handler = new JwtSecurityTokenHandler();
      var token = handler.WriteToken(secToken);

      // TODO it's just a test here, move later
      try
      {
        SecurityToken validatedToken;
        var securityKeyW = new Microsoft
                .IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key + "e"));
        var tokenValidationParameters = new TokenValidationParameters()
        {
          IssuerSigningKey = securityKey,
          RequireExpirationTime = false,
          ValidateAudience = false,
          ValidateIssuer = false,
        };
        var tokenRead = handler.ValidateToken(token, tokenValidationParameters, out validatedToken);
      } catch(Exception e)
      {
        throw new HttpResponseException(403, "Invalid sign token");
      }

      return new TokenDTO() { Token = token };
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