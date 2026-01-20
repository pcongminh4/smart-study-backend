using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Share
{
    public long ShareId { get; set; }

    public long OwnerId { get; set; }

    public long TargetId { get; set; }

    public string TargetType { get; set; } = null!;

    public string Permission { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User Owner { get; set; } = null!;
}
