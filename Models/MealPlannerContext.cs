using Microsoft.EntityFrameworkCore;

namespace MyMealPlanner.Models
{
    public class MealPlannerContext : DbContext
    {
        public MealPlannerContext() { }
        public MealPlannerContext(DbContextOptions<MealPlannerContext> options)
            : base(options)
        {

        }

        public DbSet<Meal> MealList { get; set; }
        public DbSet<MealPlan> MealPlan { get; set; }
        public DbSet<MealTime> MealTimes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
    }
}