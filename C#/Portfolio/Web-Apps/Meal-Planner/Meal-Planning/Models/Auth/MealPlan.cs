using System.ComponentModel.DataAnnotations;

namespace GoldenMenu.Models.Auth
{
    public class MealPlan
    {
        [Key]
        public int PlanID { get; set; }
        public int UserID { get; set; }

        // JSON Stored Meal Plan
        public string PlanData { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
    }
}
