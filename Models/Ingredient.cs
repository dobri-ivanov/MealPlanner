using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required, MaxLength(20)]
        public string? Unit { get; set; }

        public ICollection<RecipeIngredient>? Recipes { get; set; }
    }
}
