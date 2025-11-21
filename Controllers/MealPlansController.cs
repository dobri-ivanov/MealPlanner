using MealPlanner.DTOs.MealPlan;
using MealPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealPlansController : ControllerBase
    {
        private readonly IMealPlanService _service;

        public MealPlansController(IMealPlanService service)
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
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateMealPlanDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateMealPlanDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("{mealPlanId}/recipes")]
        public async Task<IActionResult> GetRecipes(int mealPlanId)
        {
            return Ok(await _service.GetRecipesAsync(mealPlanId));
        }

        [HttpPost("{mealPlanId}/recipes")]
        public async Task<IActionResult> AddOrUpdateRecipe(int mealPlanId, AddOrUpdateMealPlanRecipeDto dto)
        {
            await _service.AddOrUpdateRecipeAsync(mealPlanId, dto);
            return Ok();
        }

        [HttpDelete("{mealPlanId}/recipes/{recipeId}/{dayOfWeek}/{mealType}")]
        public async Task<IActionResult> DeleteRecipe(int mealPlanId, int recipeId, int dayOfWeek, string mealType)
        {
            var ok = await _service.DeleteRecipeAsync(mealPlanId, recipeId, dayOfWeek, mealType);
            return ok ? NoContent() : NotFound();
        }
    }
}
