using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Quiz
{
    public long QuizId { get; set; }

    public long UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsPublic { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();

    public virtual User User { get; set; } = null!;
}
