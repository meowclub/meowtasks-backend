using MeowTasksBackend.BLL.Services.Contract;
using MeowTasksBackend.DTO;
using MeowTasksBackend.DTO.Requests;
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
  public class MeowTaskController : ControllerBase
  {
    private readonly IMeowTaskService _meowTaskService;
    private readonly ResponseConsts _rspConsts = new();

    public MeowTaskController(IMeowTaskService meowTaskService)
    {
      _meowTaskService = meowTaskService;
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAllMeowTasks([FromQuery] string? filterByStatus)
    {
      GenericResponse<List<MeowTaskDTO>> rsp = new();

      try
      {
        var Tasks = _meowTaskService.GetAllMeowTasks(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)), filterByStatus);

        if (Tasks == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_ALL_TASKS_SUCCESS);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWTASK_NEW_TASK_SUCCESS;
        rsp.data = Tasks;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [Authorize]
    [HttpGet]
    [Route("{meowTaskId}")]
    public IActionResult GetTaskById(int meowTaskId)
    {
      GenericResponse<MeowTaskDTO> rsp = new();

      try
      {
        var FindTask = _meowTaskService.GetMeowTask(meowTaskId, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        if (FindTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_TASK_FAILED);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWTASK_GET_TASK_SUCCESS;
        rsp.data = FindTask;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [Authorize]
    [HttpGet]
    [Route("getAllMeowTasksByMeowUserId/{meowUserId}")]
    public IActionResult GetAllMeowTasksByMeowUser(int meowUserId, [FromQuery] string? filterByStatus)
    {
      GenericResponse<List<MeowTaskDTO>> rsp = new();

      try
      {
        var Tasks = _meowTaskService.GetAllMeowTasksByUser(meowUserId, filterByStatus);

        if (Tasks == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_ALL_TASKS_BY_MEOW_USER_SUCCESS);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWTASK_NEW_TASK_SUCCESS;
        rsp.data = Tasks;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [Authorize]
    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> NewMeowTask([FromBody] MeowTaskNewRequestDTO model)
    {
      GenericResponse<MeowTaskDTO> rsp = new();

      try
      {
        var newTask = await _meowTaskService.NewMeowTask(model, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        if (newTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_NEW_TASK_FAILED);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWTASK_NEW_TASK_SUCCESS;
        rsp.data = newTask;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [Authorize]
    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateMeowTask([FromBody] MeowTaskUpdateRequestDTO model)
    {
      GenericResponse<MeowTaskDTO> rsp = new();

      try
      {
        var updateTask = await _meowTaskService.UpdateMeowTask(model, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        if (updateTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_UPDATE_TASK_FAILED);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWTASK_UPDATE_TASK_SUCCESS;
        rsp.data = updateTask;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [Authorize]
    [HttpPut]
    [Route("markMeowTaskAsPending/{meowTaskId}")]
    public async Task<IActionResult> MarkMeowTaskAsPending(int meowTaskId)
    {
      GenericResponse<MeowTaskDTO> rsp = new();

      try
      {
        var markMeowTask = await _meowTaskService.MarkMeowTaskAsPending(meowTaskId, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        if (markMeowTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_MARK_MEOW_TASK_FAILED);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWTASK_MARK_MEOW_TASK_AS_PENDING_SUCCESS;
        rsp.data = markMeowTask;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [Authorize]
    [HttpPut]
    [Route("markMeowTaskAsInProcess/{meowTaskId}")]
    public async Task<IActionResult> MarkMeowTaskAsInProcess(int meowTaskId)
    {
      GenericResponse<MeowTaskDTO> rsp = new();

      try
      {
        var markMeowTask = await _meowTaskService.MarkMeowTaskAsInProcess(meowTaskId, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        if (markMeowTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_MARK_MEOW_TASK_FAILED);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWTASK_MARK_MEOW_TASK_AS_IN_PROCESS_SUCCESS;
        rsp.data = markMeowTask;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [Authorize]
    [HttpPut]
    [Route("markMeowTaskAsCompleted/{meowTaskId}")]
    public async Task<IActionResult> MarkMeowTaskAsCompleted(int meowTaskId)
    {
      GenericResponse<MeowTaskDTO> rsp = new();

      try
      {
        var markMeowTask = await _meowTaskService.MarkMeowTaskAsCompleted(meowTaskId, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        if (markMeowTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_MARK_MEOW_TASK_FAILED);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWTASK_MARK_MEOW_TASK_AS_COMPLETED_SUCCESS;
        rsp.data = markMeowTask;

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.meowOK = false;
        rsp.msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [Authorize]
    [HttpDelete]
    [Route("delete/{meowTaskId}")]
    public async Task<IActionResult> DeleteMeowTask(int meowTaskId)
    {
      GenericResponse<bool> rsp = new();

      try
      {
        var deleteTask = await _meowTaskService.DeleteMeowTask(meowTaskId, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        if (!deleteTask)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_DELETE_TASK_FAILED);

        rsp.meowOK = true;
        rsp.msg = _rspConsts.MEOWTASK_DELETE_TASK_SUCCESS;
        rsp.data = deleteTask;

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
