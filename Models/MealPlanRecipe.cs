using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models
{
    public class MealPlanRecipe
    {
        [ForeignKey(nameof(MealPlan))]
        public int MealPlanId { get; set; }
        public MealPlan? MealPlan { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

        [Column(TypeName = "int")]
        public int DayOfWeek { get; set; }

        [Required, MaxLength(20)]
        public string? MealType { get; set; }
    }
}
