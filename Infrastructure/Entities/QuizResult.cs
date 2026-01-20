using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class QuizResult
{
    public long ResultId { get; set; }

    public long QuizId { get; set; }

    public long UserId { get; set; }

    public int Score { get; set; }

    public DateTime? TakenAt { get; set; }

    public virtual Quiz Quiz { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
