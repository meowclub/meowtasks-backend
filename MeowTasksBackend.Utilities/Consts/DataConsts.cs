using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.Utilities.Consts
{
  public class DataConsts
  {
    public Dictionary<string, string> Avatars = new()
    {
      { "default", "default" },
      { "sad", "sad" },
      { "happy", "happy" },
      { "pedro", "pedro" },
      { "cute", "cute" }
    };

    public Dictionary<string, string> Colors = new()
    {
      { "red", "#ffb3ba" },
      { "orange", "#ffdfba" },
      { "yellow", "#ffffba" },
      { "green", "#baffc9" },
      { "blue", "#bae1ff" }
    };
  }
}
