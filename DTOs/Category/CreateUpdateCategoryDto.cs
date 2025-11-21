using System.ComponentModel.DataAnnotations;

namespace MealPlanner.DTOs.Category
{
    public class CreateUpdateCategoryDto
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
