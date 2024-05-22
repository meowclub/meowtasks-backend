using MeowTasksBackend.BLL.Services;
using MeowTasksBackend.BLL.Services.Contract;
using MeowTasksBackend.DTO;
using MeowTasksBackend.Utilities;
using MeowTasksBackend.Utilities.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeowTasksBackend.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MeowUserController : ControllerBase
  {
    private readonly IMeowUserService _meowUserService;
    private readonly ResponseConsts _rspConsts = new();

    public MeowUserController(IMeowUserService meowUserService)
    {
      _meowUserService = meowUserService;
    }

    [Authorize]
    [HttpGet]
    [Route("me")]
    public ActionResult<MeowUserDTO> MeMeowUser()
    {
      GenericResponse<MeowUserDTO> rsp = new();

      try
      {
        var MeowUser = _meowUserService.MeMeowUser(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        if (MeowUser == null)
          throw new TaskCanceledException(_rspConsts.MEOWUSER_ME_FAILED);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWUSER_ME_SUCCESS;
        rsp.data = MeowUser;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }
  }
}
