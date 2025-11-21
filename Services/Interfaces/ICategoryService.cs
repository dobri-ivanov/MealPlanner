using MealPlanner.DTOs.Category;

namespace MealPlanner.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto dto);
        Task<CategoryDto> UpdateAsync(int id, CreateUpdateCategoryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
