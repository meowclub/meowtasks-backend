
namespace MeowTasksBackend.Utilities
{
  public class GenericResponse<T>
  {
    public bool meowOK { get; set; }
    public T data { get; set; }
    public string msg { get; set; }
    public string date = DateTime.Now.ToString();
  }
}
