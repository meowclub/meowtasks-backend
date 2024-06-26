﻿using System;
using System.Collections.Generic;

namespace MeowTasksBackend.Entity;

public partial class MeowTask
{
    public int MeowTaskId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? Status { get; set; }

    public int? Type { get; set; }

    public bool? Private { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual MeowUser User { get; set; } = null!;
}
