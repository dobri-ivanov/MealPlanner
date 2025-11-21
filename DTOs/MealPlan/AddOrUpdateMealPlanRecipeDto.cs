using System.ComponentModel.DataAnnotations;

namespace MealPlanner.DTOs.MealPlan
{
    public class AddOrUpdateMealPlanRecipeDto
    {
        [Required]
        public int RecipeId { get; set; }

        [Required]
        [Range(1, 7)]
        public int DayOfWeek { get; set; }

        [Required, MaxLength(20)]
        public string MealType { get; set; } = null!;
    }
}
