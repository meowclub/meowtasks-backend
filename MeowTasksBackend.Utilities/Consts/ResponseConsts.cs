using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.Utilities.Consts
{
  public class ResponseConsts
  {
    // auth/register
    public string MEOWUSER_REGISTER_FAILED = "Meow user register failed...";
    public string MEOWUSER_REGISTER_SUCCESS = "Meow user register success.";
    public string MEOWUSER_REGISTER_NICKNAME_TAKED = "Nickname taked...";
    public string MEOWUSER_REGISTER_AVATAR_INCORRECT = "Avatar incorrect...";
    public string MEOWUSER_REGISTER_COLOR_INCORRECT = "Color incorrect";

    // auth/login
    public string MEOWUSER_LOGIN_INCORRECT_CREDENTIALS = "Incorrect credentials...";
    public string MEOWUSER_LOGIN_FAILED = "Meow user login failed";
    public string MEOWUSER_LOGIN_SUCESS = "Meow user logged!";

    // util/colors
    public string UTIL_COLORS_SUCCESS = "Colors";

    // util/avatars
    public string UTIL_AVATARS_SUCCESS = "Avatars";
  }
}
