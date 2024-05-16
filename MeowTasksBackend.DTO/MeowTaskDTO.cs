using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.DTO
{
  public class MeowTaskDTO
  {
    public int MeowTaskId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? Status { get; set; }
    public int? Private { get; set; }
    public int? Type { get; set; }
    public DateTime? CreatedAt { get; set; }
  }
}
