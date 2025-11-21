using System.ComponentModel.DataAnnotations;

namespace MealPlanner.DTOs.MealPlan
{
    public class CreateUpdateMealPlanDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
