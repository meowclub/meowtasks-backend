using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.DTO.Requests
{
  public class MeowUserRegisterRequestDTO
  {
    public string Nickname { get; set; }
    public string Password { get; set; }
    public string PasswordHint { get; set; }
    public string Avatar { get; set; }
    public string Color { get; set; }
  }
}
