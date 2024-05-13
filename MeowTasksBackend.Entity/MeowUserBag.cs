using System;
using System.Collections.Generic;

namespace MeowTasksBackend.Entity;

public partial class MeowUserBag
{
    public int MeowUserId { get; set; }

    public int ProductId { get; set; }

    public DateTime? PurchasedAt { get; set; }

    public int? Uses { get; set; }

    public virtual MeowUser MeowUser { get; set; } = null!;

    public virtual MeowProduct Product { get; set; } = null!;
}
