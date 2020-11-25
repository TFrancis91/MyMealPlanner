namespace MyMealPlanner.Models
{
    public class Ingredients
    {
        public long IngredientsId { get; set; }
        public long MealId { get; set; }
        public Meal Meal{get;set;}
        public string IngredientName { get; set; }
        public long IngredientTypeId { get; set; }
        public IngredientType IngredientType{get;set;}
        public long Quantity { get; set; }
    }
}