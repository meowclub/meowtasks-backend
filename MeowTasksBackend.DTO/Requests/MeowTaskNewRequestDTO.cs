using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.DTO.Requests
{
  public class MeowTaskNewRequestDTO
  {
    public string Name { get; set; }
    public string? Description { get; set; }
  }
}
