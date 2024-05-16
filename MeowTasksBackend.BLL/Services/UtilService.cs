using MeowTasksBackend.BLL.Services.Contract;
using MeowTasksBackend.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MeowTasksBackend.BLL.Services
{
  public class UtilService : IUtilService
  {
    private readonly DataConsts _dtConts = new();

    public string GetAvatars()
    {
      try
      {
        return JsonSerializer.Serialize(_dtConts.Avatars);
      }
      catch (Exception)
      {

        throw;
      }
    }

    public string GetColors()
    {
      try
      {
        return JsonSerializer.Serialize(_dtConts.Colors);
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
