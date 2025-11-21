using MealPlanner.Data;
using MealPlanner.DTOs.Ingredient;
using MealPlanner.Models;
using MealPlanner.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Api.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly MealPlannerContext _context;

        public IngredientService(MealPlannerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            return await _context.Ingredients
                .Select(i => new IngredientDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Unit = i.Unit
                })
                .ToListAsync();
        }

        public async Task<IngredientDto> GetByIdAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null) return null;

            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Unit = ingredient.Unit
            };
        }

        public async Task<IngredientDto> CreateAsync(CreateUpdateIngredientDto dto)
        {
            var ingredient = new Ingredient
            {
                Name = dto.Name,
                Unit = dto.Unit
            };

            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Unit = ingredient.Unit
            };
        }

        public async Task<IngredientDto> UpdateAsync(int id, CreateUpdateIngredientDto dto)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null) return null;

            ingredient.Name = dto.Name;
            ingredient.Unit = dto.Unit;

            await _context.SaveChangesAsync();

            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Unit = ingredient.Unit
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null) return false;

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
