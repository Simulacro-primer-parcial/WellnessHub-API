using System.ComponentModel.DataAnnotations;

namespace WellnessHub.Models;

public class Habit
{
    [Key]
    public int Id { get; set; }
    public string User { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Frequency { get; set; } = null!;
    public string Status { get; set; } = null!;
}