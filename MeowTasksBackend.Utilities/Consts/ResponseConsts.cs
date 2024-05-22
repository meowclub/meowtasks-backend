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
    public string MEOWUSER_REGISTER_PASSWORD_CONFIRMATION_NOT_MATCH = "Password confirmation not match.";

    // auth/login
    public string MEOWUSER_LOGIN_INCORRECT_CREDENTIALS = "Incorrect credentials...";
    public string MEOWUSER_LOGIN_FAILED = "Meow user login failed";
    public string MEOWUSER_LOGIN_SUCESS = "Meow user logged!";

    // util/colors
    public string UTIL_COLORS_SUCCESS = "Colors";

    // util/avatars
    public string UTIL_AVATARS_SUCCESS = "Avatars";

    //meowTask/1
    public string MEOWTASK_GET_TASK_INVALID = "Meow task not exist or meow user id is incorrect.";
    public string MEOWTASK_GET_TASK_SUCCESS = "Meow task found";
    public string MEOWTASK_GET_TASK_FAILED = "Meow task failed";

    // meowTask/
    public string MEOWTASK_GET_ALL_TASKS_INCORRECT_STATUS = "Argumented status incorrect...";
    public string MEOWTASK_GET_ALL_TASKS_SUCCESS = "All meow tasks success";

    // meowTask/getAllMeowTasksByMeowUser/1
    public string MEOWTASK_GET_ALL_TASKS_BY_MEOW_USER_INVALID_USER = "Invalid user...";
    public string MEOWTASK_GET_ALL_TASKS_BY_MEOW_USER_SUCCESS = "All meow tasks by user success";

    // meowTask/new
    public string MEOWTASK_NEW_TASK_CREATED = "This meow task is created...";
    public string MEOWTASK_NEW_TASK_FAILED = "Meow task new failed";
    public string MEOWTASK_NEW_TASK_SUCCESS = "Meow task new success";

    // meowTask/update
    public string MEOWTASK_UPDATE_TASK_FAILED = "Meow task update failed";
    public string MEOWTASK_UPDATE_TASK_SUCCESS = "Meow update task success";

    // meowTask/delete
    public string MEOWTASK_DELETE_TASK_FAILED = "Meow task delete failed";
    public string MEOWTASK_DELETE_TASK_SUCCESS = "Meow task success";

    // meowTask/markMeowTaskAsPending
    public string MEOWTASK_MARK_MEOW_TASK_AS_PENDING_SUCCESS = "Meow task now is pending";

    // meowTask/markMeowTaskAsPending
    public string MEOWTASK_MARK_MEOW_TASK_AS_IN_PROCESS_SUCCESS = "Meow task now is in process";

    // meowTask/markMeowTaskAsPending
    public string MEOWTASK_MARK_MEOW_TASK_AS_COMPLETED_SUCCESS = "Meow task now is completed";
    
    // meowTask/markMeowTaskAs | General failed
    public string MEOWTASK_MARK_MEOW_TASK_FAILED = "Meow task mark failed";

    // meowUser/me
    public string MEOWUSER_ME_SUCCESS = "MeowUser me success";
    public string MEOWUSER_ME_FAILED = "MeowUser me failed";
  }
}
