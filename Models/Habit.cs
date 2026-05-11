using System;

namespace AOOP_HABI.Models
{
    public class Habit
    {
        public string HabitID { get; set; }
        public string HabitName { get; set; }
        public Intent Intent { get; set;  }
        public TrackingType TrackingType { get; set; }
        public double TargetAmount { get; set;  } 
        public string Unit { get; set; } 
        public DateTime DateCreated { get; set; }
        public HabitCategory Category { get; set; }
        public GoalPeriod GoalPeriod { get; set; }
        public TimeRange TimeRange { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
