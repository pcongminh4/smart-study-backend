using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class User
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string? FullName { get; set; }

    public string? AvatarUrl { get; set; }

    public int? Point { get; set; }

    public string? Role { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<FlashcardSet> FlashcardSets { get; set; } = new List<FlashcardSet>();

    public virtual ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<Share> Shares { get; set; } = new List<Share>();
}
