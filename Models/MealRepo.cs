
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMealPlanner.Models
{
    [Table("MealRepo")]
    public class Meal
    {

        public long Id { get; set; }
        public string MealName { get; set; }
        public string Cuisine { get; set; }
        public string Difficulty { get; set; }
        public string MealType { get; set; }
        public long ServingSize { get; set; }
    }
}