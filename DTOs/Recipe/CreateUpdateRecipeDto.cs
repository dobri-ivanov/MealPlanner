using System.ComponentModel.DataAnnotations;

namespace MealPlanner.DTOs.Recipe
{
    public class CreateUpdateRecipeDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public string Instructions { get; set; } = null!;

        [Range(1, 1440)]
        public int CookingTimeMinutes { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int AuthorUserId { get; set; }
    }
}
