using AOOP_HABI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOOP_HABI.Services
{
    public class CsvDataService
    {
        private static readonly string HabitsFile = "habits.csv";
        private static readonly string LogsFile = "habitlogs.csv";
        private static readonly string ConfigFile = "config.txt";

        //USERNAME
        public string LoadUserName()
        {
            if (!File.Exists(ConfigFile)) return null;
            var lines = File.ReadAllLines(ConfigFile);
            foreach (var line in lines)
            {
                if (line.StartsWith("username="))
                    return line.Replace("username=", "").Trim();
            }
            return null;
        }

        public void SaveUserName(string name)
        {
            File.WriteAllText(ConfigFile, "username=" + name.Trim());
        }

        // Inside CsvDataService.cs

        public List<Habit> LoadHabits()
        {
            var habits = new List<Habit>();
            if (!File.Exists(HabitsFile)) return habits;

            var lines = File.ReadAllLines(HabitsFile);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var col = line.Split('|');
                if (col.Length < 12) continue; // UPDATED to 12 columns

                habits.Add(new Habit
                {
                    HabitID = col[0],
                    HabitName = col[1],
                    Intent = (Intent)Enum.Parse(typeof(Intent), col[2]),
                    TrackingType = (TrackingType)Enum.Parse(typeof(TrackingType), col[3]),
                    TargetAmount = double.Parse(col[4]),
                    Unit = col[5],
                    DateCreated = DateTime.Parse(col[6]),

                    // NEW PARSERS
                    Category = (HabitCategory)Enum.Parse(typeof(HabitCategory), col[7]),
                    GoalPeriod = (GoalPeriod)Enum.Parse(typeof(GoalPeriod), col[8]),
                    TimeRange = (TimeRange)Enum.Parse(typeof(TimeRange), col[9]),
                    StartDate = DateTime.Parse(col[10]),
                    EndDate = DateTime.Parse(col[11])
                });
            }
            return habits;
        }

        public void SaveHabit(Habit habit)
        {
            if (string.IsNullOrEmpty(habit.HabitID))
                habit.HabitID = Guid.NewGuid().ToString();

            var line = string.Join("|", new string[]
            {
        habit.HabitID,
        habit.HabitName,
        habit.Intent.ToString(),
        habit.TrackingType.ToString(),
        habit.TargetAmount.ToString(),
        habit.Unit ?? "",
        habit.DateCreated.ToString("yyyy-MM-dd"),
        
        // NEW SAVES
        habit.Category.ToString(),
        habit.GoalPeriod.ToString(),
        habit.TimeRange.ToString(),
        habit.StartDate.ToString("yyyy-MM-dd"),
        habit.EndDate.ToString("yyyy-MM-dd")
            });
            File.AppendAllText(HabitsFile, line + Environment.NewLine);
        }

        // Ensure you apply the exact same array string format in your UpdateHabit() method as well!

        public void DeleteHabit(string habitId)
        {
            if (!File.Exists(HabitsFile)) return;

            var lines = File.ReadAllLines(HabitsFile);
            var updated = new List<string>();

            foreach (var line in lines)
            {
                if (!line.StartsWith(habitId))
                    updated.Add(line);
            }

            File.WriteAllLines(HabitsFile, updated);
        }

        public List<HabitLog> LoadLogs()
        {
            var logs = new List<HabitLog>();

            if (!File.Exists(LogsFile)) return logs;

            var lines = File.ReadAllLines(LogsFile);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var col = line.Split('|');
                if (col.Length < 5) continue;

                logs.Add(new HabitLog
                {
                    LogID = col[0],
                    HabitID = col[1],
                    LogDate = DateTime.Parse(col[2]),
                    IsCompleted = bool.Parse(col[3]),
                    AmountLogged = double.Parse(col[4]),
                    Notes = col.Length >= 6 ? col[5] : ""
                });
            }

            return logs;
        }

        public void SaveLog(HabitLog log)
        {
            if (string.IsNullOrEmpty(log.LogID))
                log.LogID = Guid.NewGuid().ToString();

            var line = string.Join("|", new string[]
            {
                log.LogID,
                log.HabitID,
                log.LogDate.ToString("yyyy-MM-dd"),
                log.IsCompleted.ToString(),
                log.AmountLogged.ToString(),
                log.Notes ?? ""
            });

            File.AppendAllText(LogsFile, line + Environment.NewLine);
        }

        public void UpdateLog(HabitLog updatedLog)
        {
            if (!File.Exists(LogsFile)) return;

            var lines = File.ReadAllLines(LogsFile);
            var updated = new List<string>();

            foreach (var line in lines)
            {
                if (line.StartsWith(updatedLog.LogID))
                {
                    var newLine = string.Join("|", new string[]
                    {
                        updatedLog.LogID,
                        updatedLog.HabitID,
                        updatedLog.LogDate.ToString("yyyy-MM-dd"),
                        updatedLog.IsCompleted.ToString(),
                        updatedLog.AmountLogged.ToString(),
                        updatedLog.Notes ?? ""
                    });
                    updated.Add(newLine);
                }
                else
                {
                    updated.Add(line);
                }
            }

            File.WriteAllLines(LogsFile, updated);
        }

        public void UpdateHabit(Habit updatedHabit)
        {
            if (!File.Exists(HabitsFile)) return;

            var lines = File.ReadAllLines(HabitsFile);
            var updated = new List<string>();

            foreach (var line in lines)
            {
                if (line.StartsWith(updatedHabit.HabitID))
                {
                    var newLine = string.Join("|", new string[]
                    {
                updatedHabit.HabitID,
                updatedHabit.HabitName,
                updatedHabit.Intent.ToString(),
                updatedHabit.TrackingType.ToString(),
                updatedHabit.TargetAmount.ToString(),
                updatedHabit.Unit ?? "",
                updatedHabit.DateCreated.ToString("yyyy-MM-dd"),
                updatedHabit.Category.ToString(),
                updatedHabit.GoalPeriod.ToString(),
                updatedHabit.TimeRange.ToString(),
                updatedHabit.StartDate.ToString("yyyy-MM-dd"),
                updatedHabit.EndDate.ToString("yyyy-MM-dd")
                    });
                    updated.Add(newLine);
                }
                else
                {
                    updated.Add(line);
                }
            }

            File.WriteAllLines(HabitsFile, updated);
        }

        public void DeleteHabitAndLogs(string habitId)
        {
            // Delete habit
            DeleteHabit(habitId);

            // Delete all logs for this habit
            if (!File.Exists(LogsFile)) return;

            var lines = File.ReadAllLines(LogsFile);
            var updated = new List<string>();

            foreach (var line in lines)
            {
                var col = line.Split('|');
                if (col.Length >= 2 && col[1] != habitId)
                    updated.Add(line);
            }

            File.WriteAllLines(LogsFile, updated);
        }
    }
}