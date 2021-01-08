using System.Threading.Tasks;
using Yalta.Models;
using Yalta.Models.DTO;

namespace Yalta.Services
{
  public interface IUserService
  {
    Task<UserSimpleDTO> Login(User user);
    Task Registration(User user);
  }
}