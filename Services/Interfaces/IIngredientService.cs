using MealPlanner.DTOs.Ingredient;

namespace MealPlanner.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetAllAsync();
        Task<IngredientDto> GetByIdAsync(int id);
        Task<IngredientDto> CreateAsync(CreateUpdateIngredientDto dto);
        Task<IngredientDto> UpdateAsync(int id, CreateUpdateIngredientDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
