using System.ComponentModel.DataAnnotations;

namespace Movies_API.Models.Viewmodels
{
    public class AuthViewmodel
    {
        [Required]
        public string Email { get; set; }
        [Required]   
        public string Password { get; set; }
    }
}
