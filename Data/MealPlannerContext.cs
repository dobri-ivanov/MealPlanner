using MealPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Data
{
    public class MealPlannerContext : DbContext
    {
        public MealPlannerContext(DbContextOptions<MealPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<MealPlanRecipe> MealPlanRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for RecipeIngredients
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            // Composite key for MealPlanRecipe
            modelBuilder.Entity<MealPlanRecipe>()
                .HasKey(mpr => new { mpr.MealPlanId, mpr.RecipeId, mpr.DayOfWeek, mpr.MealType });

            modelBuilder.Entity<MealPlanRecipe>()
                .HasOne(mpr => mpr.MealPlan)
                .WithMany(mp => mp.Recipes)
                .HasForeignKey(mpr => mpr.MealPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MealPlanRecipe>()
                .HasOne(mpr => mpr.Recipe)
                .WithMany(r => r.MealPlans)
                .HasForeignKey(mpr => mpr.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
