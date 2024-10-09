﻿using System;
using System.Collections.Generic;

namespace Movies_API.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string Genre1 { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}