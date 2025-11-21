using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models
{
    public class RecipeIngredient
    {
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }
    }
}
