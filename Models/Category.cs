using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public ICollection<Recipe>? Recipes { get; set; }
    }
}
