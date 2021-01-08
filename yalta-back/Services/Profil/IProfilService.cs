using System.Threading.Tasks;
using Yalta.Models;
using Yalta.Models.DTO;
using System.Collections.Generic;

namespace Yalta.Services
{
  public interface IProfilService
  {
    Task<IEnumerable<ProfilDTO>> GetAll();
  }
}