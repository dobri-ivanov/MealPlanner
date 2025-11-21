using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? Username { get; set; }

        [Required, MaxLength(100)]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<MealPlan>? MealPlans { get; set; }
    }
}
