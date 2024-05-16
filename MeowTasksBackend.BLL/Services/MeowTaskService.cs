using AutoMapper;
using MeowTasksBackend.BLL.Services.Contract;
using MeowTasksBackend.DAL.Repositories.Contract;
using MeowTasksBackend.DTO;
using MeowTasksBackend.DTO.Requests;
using MeowTasksBackend.Entity;
using MeowTasksBackend.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.BLL.Services
{
  public class MeowTaskService : IMeowTaskService
  {
    private readonly IGenericRepository<MeowTask> _meowTaskRepository;
    private readonly IGenericRepository<MeowUser> _meowUserRepository;
    private readonly IMapper _mapper;
    private readonly ValueConsts _valueConsts = new();
    private readonly ResponseConsts _rspConsts = new();

    public MeowTaskService(IGenericRepository<MeowTask> meowTaskRepository, IGenericRepository<MeowUser> meowUserRepository, IMapper mapper)
    {
      _meowTaskRepository = meowTaskRepository;
      _meowUserRepository = meowUserRepository;
      _mapper = mapper;
    }

    public async Task<MeowTaskDTO> NewMeowTask(MeowTaskNewRequestDTO model, int meowUserId)
    {
      try
      {
        var FindTask = _meowTaskRepository.Get(t => t.Name == model.Name);

        if (FindTask != null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_NEW_TASK_CREATED);

        var newTask = _mapper.Map<MeowTask>(model);
        newTask.UserId = meowUserId;

        var createTask = await _meowTaskRepository.Create(newTask);

        return _mapper.Map<MeowTaskDTO>(createTask);
      }
      catch (Exception)
      {
        throw;
      }
    }
    public MeowTaskDTO GetMeowTask(int meowTaskId, int meowUserId)
    {

      var FindTask = _meowTaskRepository.Get(t => t.MeowTaskId == meowTaskId && t.UserId == meowUserId);

      if (FindTask == null)
        throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_TASK_FAILED);

      return _mapper.Map<MeowTaskDTO>(FindTask);
    }

    public async Task<MeowTaskDTO> UpdateMeowTask(MeowTaskUpdateRequestDTO model, int meowUserId)
    {
      try
      {
        var FindTask = _meowTaskRepository.Get(t => t.MeowTaskId == model.MeowTaskId && t.UserId == meowUserId);

        if (FindTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_TASK_INVALID);

        FindTask.Name = model.Name != null ? model.Name : FindTask.Name;
        FindTask.Description = model.Description != null ? model.Description : FindTask.Description;
        FindTask.Status = model.Status != null ? model.Status : FindTask.Status;
        FindTask.Type = model.Type != null ? model.Type : FindTask.Type;

        var UpdateTask = await _meowTaskRepository.Update(FindTask);

        return _mapper.Map<MeowTaskDTO>(FindTask);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteMeowTask(int meowTaskId, int meowUserId)
    {
      try
      {
        var FindTask = _meowTaskRepository.Get(t => t.MeowTaskId == meowTaskId && t.UserId == meowUserId);

        if (FindTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_DELETE_TASK_FAILED);

        var DeleteTask = await _meowTaskRepository.Delete(FindTask);

        return DeleteTask;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<MeowTaskDTO> MarkMeowTaskAsPending(int meowTaskId, int meowUserId)
    {
      try
      {
        var FindTask = _meowTaskRepository.Get(t => t.MeowTaskId == meowTaskId && t.UserId == meowUserId);

        if (FindTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_TASK_INVALID);

        FindTask.Status = _valueConsts.MeowTaskStatus["pending"];

        var UpdateTask = await _meowTaskRepository.Update(FindTask);

        return _mapper.Map<MeowTaskDTO>(FindTask);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<MeowTaskDTO> MarkMeowTaskAsInProcess(int meowTaskId, int meowUserId)
    {
      try
      {
        var FindTask = _meowTaskRepository.Get(t => t.MeowTaskId == meowTaskId && t.UserId == meowUserId);

        if (FindTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_TASK_INVALID);

        FindTask.Status = _valueConsts.MeowTaskStatus["in_process"];

        var UpdateTask = await _meowTaskRepository.Update(FindTask);

        return _mapper.Map<MeowTaskDTO>(FindTask);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<MeowTaskDTO> MarkMeowTaskAsCompleted(int meowTaskId, int meowUserId)
    {
      try
      {
        var FindTask = _meowTaskRepository.Get(t => t.MeowTaskId == meowTaskId && t.UserId == meowUserId);

        if (FindTask == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_TASK_INVALID);

        FindTask.Status = _valueConsts.MeowTaskStatus["completed"];

        var UpdateTask = await _meowTaskRepository.Update(FindTask);

        return _mapper.Map<MeowTaskDTO>(FindTask);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<MeowTaskDTO> GetAllMeowTasks(int meowUserId, string? filterByStatus)
    {
      try
      {
        var FindStatus = _valueConsts.MeowTaskStatus.Where(s => s.Key == filterByStatus).FirstOrDefault();

        if (filterByStatus != null && FindStatus.Key == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_ALL_TASKS_INCORRECT_STATUS);

        var FindTasks = _meowTaskRepository.Query(t => t.UserId == meowUserId).ToList();

        if (filterByStatus != null)
        {
          FindTasks = FindTasks.Where(t => t.Status == FindStatus.Value).ToList();
        }

        return _mapper.Map<List<MeowTaskDTO>>(FindTasks);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<MeowTaskDTO> GetAllMeowTasksByUser(int meowUserId, string? filterByStatus)
    {
      try
      {
        var FindStatus = _valueConsts.MeowTaskStatus.Where(s => s.Key == filterByStatus).FirstOrDefault();

        if (filterByStatus != null && FindStatus.Key == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_ALL_TASKS_INCORRECT_STATUS);

        // Check if meow user id is valid
        var FindUser = _meowUserRepository.Get(u => u.MeowUserId == meowUserId);

        if (FindUser == null)
          throw new TaskCanceledException(_rspConsts.MEOWTASK_GET_ALL_TASKS_BY_MEOW_USER_INVALID_USER);

        var FindTasks = _meowTaskRepository.Query(t => t.UserId == meowUserId && t.Private == false).ToList();

        if (filterByStatus != null)
        {
          FindTasks = FindTasks.Where(t => t.Status == FindStatus.Value).ToList();
        }

        return _mapper.Map<List<MeowTaskDTO>>(FindTasks);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
