namespace MealPlanner.DTOs.Recipe
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Instructions { get; set; } = null!;
        public int CookingTimeMinutes { get; set; }
        public int CategoryId { get; set; }
        public int AuthorUserId { get; set; }
    }
}
