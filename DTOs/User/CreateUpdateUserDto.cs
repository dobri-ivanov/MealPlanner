using System.ComponentModel.DataAnnotations;

namespace MealPlanner.DTOs.User
{
    public class CreateUpdateUserDto
    {
        [Required, MaxLength(50)]
        public string? Username { get; set; }

        [Required, MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Password { get; set; }
    }
}
