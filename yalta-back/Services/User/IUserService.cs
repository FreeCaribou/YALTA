using System.Threading.Tasks;
using Yalta.Models;
using Yalta.Models.DTO;

namespace Yalta.Services
{
  public interface IUserService
  {
    Task<TokenDTO> Login(User user);
    Task Registration(UserSignUpDTO user);
  }
}