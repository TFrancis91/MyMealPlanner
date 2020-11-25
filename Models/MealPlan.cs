namespace MyMealPlanner.Models
{
    public class MealPlan
    {
        public long MealTimeId { get; set; }
        public long MealId { get; set; }    
        public MealTime MealTime{get;set;}    
        public Meal Meal{get;set;}
        public string Date{get;set;}
        public long MealPlanId{get;set;}

    }
}