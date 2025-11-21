namespace MealPlanner.DTOs.MealPlan
{
    public class MealPlanDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
