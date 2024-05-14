using MeowTasksBackend.BLL.Services.Contract;
using MeowTasksBackend.DTO;
using MeowTasksBackend.DTO.Requests;
using MeowTasksBackend.Utilities;
using MeowTasksBackend.Utilities.Consts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeowTasksBackend.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _authService;
    private readonly ResponseConsts _rspConsts = new();

    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> RegisterMeowUser([FromBody] MeowUserRegisterRequestDTO model)
    {
      GenericResponse<string> rsp = new();

      try
      {
        var token = await _authService.RegisterMeowUser(model);

        if (token == null)
        {
          rsp.meowOK = false;
          rsp.msg = _rspConsts.MEOWUSER_REGISTER_FAILED;

          return BadRequest(rsp);
        }

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWUSER_REGISTER_SUCCESS;
        rsp.data = token;
        
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
