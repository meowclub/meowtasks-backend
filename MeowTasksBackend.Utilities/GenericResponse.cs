
namespace MeowTasksBackend.Utilities
{
  public class GenericResponse<T>
  {
    public bool meowOK { get; set; }
    public string data { get; set; }
    public string msg { get; set; }
    public string date = DateTime.Now.ToString();
  }
}
