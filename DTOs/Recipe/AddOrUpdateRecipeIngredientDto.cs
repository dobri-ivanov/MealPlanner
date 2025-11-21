using System.ComponentModel.DataAnnotations;

namespace MealPlanner.DTOs.Recipe;

public class AddOrUpdateRecipeIngredientDto
{
    [Required]
    public int IngredientId { get; set; }

    [Required]
    [Range(0.01, 99999)]
    public decimal Quantity { get; set; }
}
