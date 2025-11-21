namespace MealPlanner.DTOs.MealPlan
{
    public class MealPlanRecipeDto
    {
        public int RecipeId { get; set; }
        public int DayOfWeek { get; set; }
        public string MealType { get; set; } = null!;

        public string RecipeName { get; set; } = null!;
        public int CookingTimeMinutes { get; set; }
    }
}
