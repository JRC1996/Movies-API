using System.ComponentModel.DataAnnotations;

namespace Movies_API.Models.Viewmodels
{
    public class MovieViewmodel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int IdGenre { get; set; }
        
        public string? Genre { get; set; }
        [Required]
        public int IdAgeRating { get; set; }
       
        public string? Rating { get; set; }
        [Required]
        public DateOnly ReleaseDate { get; set; }

    }
}
