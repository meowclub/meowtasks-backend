
namespace MeowTasksBackend.DTO
{
  public class MeowUserDTO
  {
    public int MeowUserId { get; set; }
    public string Nickname { get; set; } = null!;
    public string PasswordHint { get; set; } = null!;
    public int? MeowPoints { get; set; }
    public string? Avatar { get; set; }
    public string? Color { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
  }
}
