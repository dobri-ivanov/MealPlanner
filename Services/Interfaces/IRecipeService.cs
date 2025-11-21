using MealPlanner.DTOs.Recipe;

namespace MealPlanner.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetAllAsync();
        Task<RecipeDto> GetByIdAsync(int id);
        Task<RecipeDto> CreateAsync(CreateUpdateRecipeDto dto);
        Task<RecipeDto> UpdateAsync(int id, CreateUpdateRecipeDto dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<RecipeIngredientDto>> GetIngredientsAsync(int recipeId);
        Task<bool> AddOrUpdateIngredientAsync(int recipeId, AddOrUpdateRecipeIngredientDto dto);
        Task<bool> DeleteIngredientAsync(int recipeId, int ingredientId);
    }
}
