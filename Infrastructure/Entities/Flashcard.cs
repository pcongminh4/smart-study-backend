using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Flashcard
{
    public long CardId { get; set; }

    public long SetId { get; set; }

    public string Front { get; set; } = null!;

    public string Back { get; set; } = null!;

    public virtual FlashcardSet Set { get; set; } = null!;
}
