using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class FlashcardSet
{
    public long SetId { get; set; }

    public long UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsPublic { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Flashcard> Flashcards { get; set; } = new List<Flashcard>();

    public virtual User User { get; set; } = null!;
}
