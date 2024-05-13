using System;
using System.Collections.Generic;

namespace MeowTasksBackend.Entity;

public partial class MeowProduct
{
    public int MeowProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? Type { get; set; }

    public string? Value { get; set; }

    public int Uses { get; set; }

    public int MeowPoints { get; set; }

    public DateTime? CreatedAt { get; set; }
}
