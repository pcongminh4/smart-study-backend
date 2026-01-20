using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class QuestionOption
{
    public long OptionId { get; set; }

    public long QuestionId { get; set; }

    public string Content { get; set; } = null!;

    public bool? IsCorrect { get; set; }

    public virtual Question Question { get; set; } = null!;
}
