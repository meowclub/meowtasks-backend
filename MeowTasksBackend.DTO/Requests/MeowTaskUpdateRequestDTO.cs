using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.DTO.Requests
{
  public class MeowTaskUpdateRequestDTO
  {
    public int MeowTaskId { get; set; }
    public string? Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? Status { get; set; }
    public int? Type { get; set; }
  }
}
