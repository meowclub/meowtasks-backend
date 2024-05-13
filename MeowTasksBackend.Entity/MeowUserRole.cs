using System;
using System.Collections.Generic;

namespace MeowTasksBackend.Entity;

public partial class MeowUserRole
{
    public int RoleId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual MeowUser User { get; set; } = null!;
}
