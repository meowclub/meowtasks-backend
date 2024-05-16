using System;
using System.Collections.Generic;

namespace MeowTasksBackend.Entity;

public partial class MeowUser
{
    public int MeowUserId { get; set; }

    public string Nickname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordHint { get; set; } = null!;

    public int? MeowPoints { get; set; }

    public string? Avatar { get; set; }

    public string? Color { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<MeowTask> MeowTasks { get; set; } = new List<MeowTask>();

    public virtual ICollection<MeowUserRole> MeowUserRoles { get; set; } = new List<MeowUserRole>();
}
