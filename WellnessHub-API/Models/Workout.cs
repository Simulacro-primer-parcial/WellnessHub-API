using System.ComponentModel.DataAnnotations;

namespace WellnessHub.Models
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string User { get; set; } = string.Empty;

        [Required]
        public DateTime SessionDate { get; set; }

        [Required]
        public string Exercise { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int DurationMinutes { get; set; }

        [Range(0, 10000)]
        public int IntensityCalories { get; set; }

        [Range(0, 10000)]
        public int CaloriesBurned { get; set; }
    }
}