using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        public string? Instructions { get; set; }

        [Column(TypeName = "int")]
        public int CookingTimeMinutes { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey(nameof(AuthorUser))]
        public int AuthorUserId { get; set; }
        public User? AuthorUser { get; set; }

        public ICollection<RecipeIngredient>? Ingredients { get; set; }
        public ICollection<MealPlanRecipe>? MealPlans { get; set; }
    }
}
