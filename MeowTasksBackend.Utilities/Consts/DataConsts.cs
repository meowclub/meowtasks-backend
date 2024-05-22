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
      { "default", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSzlWNxVLktOUFS4XKHGMkdB4k9ICzzFdDoJbxOvU-IeQ&s" },
      { "sad", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSTcEjrARLpxNgKA4lv4jWsLdUS8cYgebrDqbRxumRJ0w&s" },
      { "happy", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3YBJpHnNF66LHV9i9c4YhTsafnDKUfstG8XW90NOy_w&s" },
      { "pedro", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2zMUgl8o7RNW7qxm0GZL97o9vyqhmW2wvDK4Ae9lt-bT8fpEzjfrF15x85EVyz3-_m88&usqp=CAU" },
      { "cute", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1UMj_tOmJ6HjPSKkaQ50waJfftPdbCzXGkvnZ5XaTKw&s" }
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
