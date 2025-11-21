using MealPlanner.DTOs.MealPlan;

namespace MealPlanner.Services.Interfaces
{
    public interface IMealPlanService
    {
        Task<IEnumerable<MealPlanDto>> GetAllAsync();
        Task<MealPlanDto> GetByIdAsync(int id);
        Task<MealPlanDto> CreateAsync(CreateUpdateMealPlanDto dto);
        Task<MealPlanDto> UpdateAsync(int id, CreateUpdateMealPlanDto dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<MealPlanRecipeDto>> GetRecipesAsync(int mealPlanId);
        Task<bool> AddOrUpdateRecipeAsync(int mealPlanId, AddOrUpdateMealPlanRecipeDto dto);
        Task<bool> DeleteRecipeAsync(int mealPlanId, int recipeId, int dayOfWeek, string mealType);
    }
}
