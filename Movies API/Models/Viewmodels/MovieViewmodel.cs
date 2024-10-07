namespace Movies_API.Models.Viewmodels
{
    public class MovieViewmodel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int IdGenre { get; set; }

        public string? Genre { get; set; }

        public int IdAgeRating { get; set; }

        public string? Rating { get; set; }

        public DateOnly ReleaseDate { get; set; }

    }
}
