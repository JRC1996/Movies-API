using System.ComponentModel.DataAnnotations;

namespace Movies.Models.ViewModels
{
    public class GenreViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
