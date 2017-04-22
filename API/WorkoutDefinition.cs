using System;
using System.Collections.Generic;
using System.Linq;
using Workouts.API.Interfaces;

namespace Workouts.API 
{
    public class WorkoutDefinition : IWorkoutDefinition
    {
        private Dictionary<string, ExerciseConfig> exercises = new Dictionary<string, ExerciseConfig>
        {
            {"Back Squat", new ExerciseConfig() { DefaultWeight = 20.0, IncrementFunction = "IncrementByPercentage" } },
            {"Bench Press", new ExerciseConfig() { DefaultWeight = 20.0, IncrementFunction = "IncrementByPercentage" } },
            {"Deadlift", new ExerciseConfig() { DefaultWeight = 20.0, IncrementFunction = "IncrementByPercentage" } },
            {"Bench Dips", new ExerciseConfig() { DefaultWeight = 20.0, IncrementFunction = "IncrementByPercentage" } },
            {"Lateral Pull-downs", new ExerciseConfig() { DefaultWeight = 20.0, IncrementFunction = "IncrementByPercentage" } },
            {"Shoulder Press", new ExerciseConfig() { DefaultWeight = 20.0, IncrementFunction = "IncrementByPercentage" } },
            {"Lunges", new ExerciseConfig() { DefaultWeight = 20.0, IncrementFunction = "IncrementByPercentage" } }            
        };

        public List<string> GetWorkoutDefinition()
        {
            return this.exercises.Keys.ToList();
        }

        public double GetNextWeight(Exercise latestExercise, Exercise previousExercise)
        {
            // If one, return that weight
            if(previousExercise == null)
            {
                return latestExercise.Weight;
            }

            // If different weight, return last weight
            if(latestExercise.Weight != previousExercise.Weight)
            {
                return latestExercise.Weight;
            }

            // Increment last weight and return
            return IncrementByPercentage(latestExercise.Weight);
        }

        private double IncrementByPercentage(double weight)
        {
            var newWeight = (weight * 1.1);
            return newWeight - (newWeight % 2.5);
        }

        private class ExerciseConfig {
            public double DefaultWeight { get; set; }

            public string IncrementFunction { get; set; }
        }
    }
}