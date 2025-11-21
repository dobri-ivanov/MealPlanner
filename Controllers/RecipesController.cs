using MealPlanner.DTOs.Recipe;
using MealPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _service;

        public RecipesController(IRecipeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recipe = await _service.GetByIdAsync(id);
            if (recipe == null) return NotFound();
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateRecipeDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateRecipeDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpGet("{recipeId}/ingredients")]
        public async Task<IActionResult> GetIngredients(int recipeId)
        {
            var items = await _service.GetIngredientsAsync(recipeId);
            return Ok(items);
        }

        [HttpPost("{recipeId}/ingredients")]
        public async Task<IActionResult> AddOrUpdateIngredient(
    int recipeId, AddOrUpdateRecipeIngredientDto dto)
        {
            var ok = await _service.AddOrUpdateIngredientAsync(recipeId, dto);
            return ok ? Ok() : BadRequest();
        }

        [HttpDelete("{recipeId}/ingredients/{ingredientId}")]
        public async Task<IActionResult> DeleteIngredient(int recipeId, int ingredientId)
        {
            var ok = await _service.DeleteIngredientAsync(recipeId, ingredientId);
            return ok ? NoContent() : NotFound();
        }


    }
}
