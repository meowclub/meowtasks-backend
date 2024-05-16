using MeowTasksBackend.DTO;
using MeowTasksBackend.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.BLL.Services.Contract
{
  public interface IMeowTaskService
  {
    Task<MeowTaskDTO> NewMeowTask(MeowTaskNewRequestDTO model, int meowUserId);
    MeowTaskDTO GetMeowTask(int meowTaskId, int meowUserId);
    Task<MeowTaskDTO> UpdateMeowTask(MeowTaskUpdateRequestDTO model, int meowUserId);
    Task<bool> DeleteMeowTask(int meowTaskId, int meowUserId);
    Task<MeowTaskDTO> MarkMeowTaskAsPending(int meowTaskId, int meowUserId);
    Task<MeowTaskDTO> MarkMeowTaskAsInProcess(int meowTaskId, int meowUserId);
    Task<MeowTaskDTO> MarkMeowTaskAsCompleted(int meowTaskId, int meowUserId);
    List<MeowTaskDTO> GetAllMeowTasks(int meowUserId, string? filterByStatus);
    List<MeowTaskDTO> GetAllMeowTasksByUser(int meowUserId, string? filterByStatus);
  }
}
