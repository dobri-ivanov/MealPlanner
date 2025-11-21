using System.ComponentModel.DataAnnotations;

namespace MealPlanner.DTOs.Ingredient
{
    public class CreateUpdateIngredientDto
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required, MaxLength(20)]
        public string? Unit { get; set; }
    }
}
