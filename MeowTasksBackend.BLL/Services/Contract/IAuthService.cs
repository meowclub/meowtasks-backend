using MeowTasksBackend.DTO;
using MeowTasksBackend.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.BLL.Services.Contract
{
  public interface IAuthService
  {
    Task<string> RegisterMeowUser(MeowUserRegisterRequestDTO model);
    Task<string> LoginMeowUser(MeowUserLoginRequestDTO model);
  }
}
