using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Question
{
    public long QuestionId { get; set; }

    public long QuizId { get; set; }

    public string Content { get; set; } = null!;

    public virtual ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();

    public virtual Quiz Quiz { get; set; } = null!;
}
