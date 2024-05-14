using MeowTasksBackend.Utilities;
using MeowTasksBackend.Utilities.Consts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MeowTasksBackend.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UtilController : ControllerBase
  {
    private readonly DataConsts _dtConts = new();
    private readonly ResponseConsts _rspConsts = new();

    [HttpGet]
    [Route("colors")]
    public IActionResult GetColors()
    {
      GenericResponse<string> rsp = new();
        
      try
      {
        var Colors = JsonSerializer.Serialize(_dtConts.Colors);

        rsp.meowOK = true;
        rsp.data = Colors;
        rsp.msg = _rspConsts.UTIL_COLORS_SUCCESS;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [HttpGet]
    [Route("avatars")]
    public IActionResult GetAvatars()
    {
      GenericResponse<string> rsp = new();

      try
      {
        var Avatars = JsonSerializer.Serialize(_dtConts.Avatars);

        rsp.meowOK = true;
        rsp.data = Avatars;
        rsp.msg = _rspConsts.UTIL_AVATARS_SUCCESS;

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
