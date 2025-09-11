using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WellnessHubAPI.Models;

[Table("meals")]
public class Meal
{
    [Key] public int Id { get; set; }

    [Required, StringLength(64)]
    public string User { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime Entry_Date { get; set; }   // yyyy-MM-dd

    [Required, StringLength(120)]
    public string Food_Name { get; set; } = null!;

    [Range(0, 5000)]
    public int Calories { get; set; }

    [Range(0, 1000)]
    public decimal Protein { get; set; }

    [Range(0, 1000)]
    public decimal Carbs { get; set; }

    [Range(0, 1000)]
    public decimal Fat { get; set; }
}