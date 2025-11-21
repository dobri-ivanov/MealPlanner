namespace MealPlanner.DTOs.Recipe
{
    public class RecipeIngredientDto
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }

        public string IngredientName { get; set; } = null!;
        public string Unit { get; set; } = null!;
    }
}
