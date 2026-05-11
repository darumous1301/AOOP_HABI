using System;
using System.Security.Policy;

namespace AOOP_HABI.Models
{
    public class HabitLog
    {
        public string LogID { get; set; }
        public string HabitID { get; set; } 
        public DateTime LogDate { get; set; }
        public bool IsCompleted { get; set; } 
        public double AmountLogged { get; set; }
        public string Notes { get; set; }
    }
}
