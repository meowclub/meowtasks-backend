using MeowTasksBackend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.BLL.Services.Contract
{
  public interface IMeowUserService
  {
    MeowUserDTO MeMeowUser(int meowUserId);
  }
}
