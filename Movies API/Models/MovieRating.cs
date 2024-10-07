using System;
using System.Collections.Generic;

namespace Movies_API.Models;

public partial class MovieRating
{
    public int Id { get; set; }

    public string Rating { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
