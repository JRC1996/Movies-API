using System.ComponentModel.DataAnnotations;

namespace Movies_API.Models.Viewmodels
{
    public class MovieRatingViewmodel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Rating { get; set; }

    }
}
