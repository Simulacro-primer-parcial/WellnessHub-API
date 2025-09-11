using System;
using System.ComponentModel.DataAnnotations;

namespace WellnessHub_API.Models
{
    public class MoodEntry
    {
        [Key]
        public int Id { get; set; }

        public string User { get; set; }

        public DateTime EntryDate { get; set; }

        public string Mood { get; set; }

        public int Energy { get; set; }

        public double SleepHours { get; set; }

        public int StressLevel { get; set; }
    }
}