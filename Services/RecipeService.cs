using MealPlanner.Data;
using MealPlanner.DTOs.Recipe;
using MealPlanner.Models;
using MealPlanner.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Api.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly MealPlannerContext _context;

        public RecipeService(MealPlannerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeDto>> GetAllAsync()
        {
            return await _context.Recipes
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Instructions = r.Instructions,
                    CookingTimeMinutes = r.CookingTimeMinutes,
                    CategoryId = r.CategoryId,
                    AuthorUserId = r.AuthorUserId
                })
                .ToListAsync();
        }

        public async Task<RecipeDto> GetByIdAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return null;

            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Instructions = recipe.Instructions,
                CookingTimeMinutes = recipe.CookingTimeMinutes,
                CategoryId = recipe.CategoryId,
                AuthorUserId = recipe.AuthorUserId
            };
        }

        public async Task<RecipeDto> CreateAsync(CreateUpdateRecipeDto dto)
        {
            var recipe = new Recipe
            {
                Name = dto.Name,
                Instructions = dto.Instructions,
                CookingTimeMinutes = dto.CookingTimeMinutes,
                CategoryId = dto.CategoryId,
                AuthorUserId = dto.AuthorUserId
            };

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Instructions = recipe.Instructions,
                CookingTimeMinutes = recipe.CookingTimeMinutes,
                CategoryId = recipe.CategoryId,
                AuthorUserId = recipe.AuthorUserId
            };
        }

        public async Task<RecipeDto> UpdateAsync(int id, CreateUpdateRecipeDto dto)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return null;

            recipe.Name = dto.Name;
            recipe.Instructions = dto.Instructions;
            recipe.CookingTimeMinutes = dto.CookingTimeMinutes;
            recipe.CategoryId = dto.CategoryId;
            recipe.AuthorUserId = dto.AuthorUserId;

            await _context.SaveChangesAsync();

            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Instructions = recipe.Instructions,
                CookingTimeMinutes = recipe.CookingTimeMinutes,
                CategoryId = recipe.CategoryId,
                AuthorUserId = recipe.AuthorUserId
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return false;

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RecipeIngredientDto>> GetIngredientsAsync(int recipeId)
        {
            return await _context.RecipeIngredients
                .Where(ri => ri.RecipeId == recipeId)
                .Select(ri => new RecipeIngredientDto
                {
                    RecipeId = ri.RecipeId,
                    IngredientId = ri.IngredientId,
                    Quantity = ri.Quantity,
                    IngredientName = ri.Ingredient.Name,
                    Unit = ri.Ingredient.Unit
                })
                .ToListAsync();
        }

        public async Task<bool> AddOrUpdateIngredientAsync(int recipeId, AddOrUpdateRecipeIngredientDto dto)
        {
            var entity = await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == dto.IngredientId);

            if (entity == null)
            {
                entity = new RecipeIngredient
                {
                    RecipeId = recipeId,
                    IngredientId = dto.IngredientId,
                    Quantity = dto.Quantity
                };
                _context.RecipeIngredients.Add(entity);
            }
            else
            {
                entity.Quantity = dto.Quantity;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIngredientAsync(int recipeId, int ingredientId)
        {
            var entity = await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);

            if (entity == null) return false;

            _context.RecipeIngredients.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
