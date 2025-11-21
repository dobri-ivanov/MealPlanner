using MealPlanner.DTOs.User;

namespace MealPlanner.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(CreateUpdateUserDto dto);
        Task<UserDto> UpdateAsync(int id, CreateUpdateUserDto dto);
        Task<bool> DeleteAsync(int id);
        Task<UserDto> LoginAsync(string username, string password);
    }
}
