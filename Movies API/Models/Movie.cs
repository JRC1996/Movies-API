using System;
using System.Collections.Generic;

namespace Movies_API.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdGenre { get; set; }

    public int IdAgeRating { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public virtual MovieRating IdAgeRatingNavigation { get; set; } = null!;

    public virtual Genre IdGenreNavigation { get; set; } = null!;
}
