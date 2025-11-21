using MealPlanner.Data;
using MealPlanner.DTOs.MealPlan;
using MealPlanner.Models;
using MealPlanner.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Api.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly MealPlannerContext _context;

        public MealPlanService(MealPlannerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MealPlanDto>> GetAllAsync()
        {
            return await _context.MealPlans
                .Select(mp => new MealPlanDto
                {
                    Id = mp.Id,
                    UserId = mp.UserId,
                    Name = mp.Name,
                    StartDate = mp.StartDate,
                    EndDate = mp.EndDate
                })
                .ToListAsync();
        }

        public async Task<MealPlanDto> GetByIdAsync(int id)
        {
            var mp = await _context.MealPlans.FindAsync(id);
            if (mp == null) return null;

            return new MealPlanDto
            {
                Id = mp.Id,
                UserId = mp.UserId,
                Name = mp.Name,
                StartDate = mp.StartDate,
                EndDate = mp.EndDate
            };
        }

        public async Task<MealPlanDto> CreateAsync(CreateUpdateMealPlanDto dto)
        {
            var mp = new MealPlan
            {
                UserId = dto.UserId,
                Name = dto.Name,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CreatedAt = DateTime.UtcNow
            };

            _context.MealPlans.Add(mp);
            await _context.SaveChangesAsync();

            return new MealPlanDto
            {
                Id = mp.Id,
                UserId = mp.UserId,
                Name = mp.Name,
                StartDate = mp.StartDate,
                EndDate = mp.EndDate
            };
        }

        public async Task<MealPlanDto> UpdateAsync(int id, CreateUpdateMealPlanDto dto)
        {
            var mp = await _context.MealPlans.FindAsync(id);
            if (mp == null) return null;

            mp.Name = dto.Name;
            mp.UserId = dto.UserId;
            mp.StartDate = dto.StartDate;
            mp.EndDate = dto.EndDate;

            await _context.SaveChangesAsync();

            return new MealPlanDto
            {
                Id = mp.Id,
                UserId = mp.UserId,
                Name = mp.Name,
                StartDate = mp.StartDate,
                EndDate = mp.EndDate
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var mp = await _context.MealPlans.FindAsync(id);
            if (mp == null) return false;

            _context.MealPlans.Remove(mp);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MealPlanRecipeDto>> GetRecipesAsync(int mealPlanId)
        {
            return await _context.MealPlanRecipes
                .Where(mpr => mpr.MealPlanId == mealPlanId)
                .Select(mpr => new MealPlanRecipeDto
                {
                    RecipeId = mpr.RecipeId,
                    DayOfWeek = mpr.DayOfWeek,
                    MealType = mpr.MealType,
                    RecipeName = mpr.Recipe.Name,
                    CookingTimeMinutes = mpr.Recipe.CookingTimeMinutes
                })
                .ToListAsync();
        }

        public async Task<bool> AddOrUpdateRecipeAsync(int mealPlanId, AddOrUpdateMealPlanRecipeDto dto)
        {
            var existing = await _context.MealPlanRecipes
                .FirstOrDefaultAsync(mpr =>
                    mpr.MealPlanId == mealPlanId &&
                    mpr.RecipeId == dto.RecipeId &&
                    mpr.DayOfWeek == dto.DayOfWeek &&
                    mpr.MealType == dto.MealType);

            if (existing == null)
            {
                existing = new MealPlanRecipe
                {
                    MealPlanId = mealPlanId,
                    RecipeId = dto.RecipeId,
                    DayOfWeek = dto.DayOfWeek,
                    MealType = dto.MealType
                };

                _context.MealPlanRecipes.Add(existing);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRecipeAsync(int mealPlanId, int recipeId, int dayOfWeek, string mealType)
        {
            var entity = await _context.MealPlanRecipes
                .FirstOrDefaultAsync(mpr =>
                    mpr.MealPlanId == mealPlanId &&
                    mpr.RecipeId == recipeId &&
                    mpr.DayOfWeek == dayOfWeek &&
                    mpr.MealType == mealType);

            if (entity == null) return false;

            _context.MealPlanRecipes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
