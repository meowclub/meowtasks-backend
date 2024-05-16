using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.Utilities.Consts
{
  public class ValueConsts
  {
    public Dictionary<string, int> MeowTaskStatus = new()
    {
      { "pending", 0 },
      { "in_process", 1 },
      { "completed", 2 }
    };
  }
}
