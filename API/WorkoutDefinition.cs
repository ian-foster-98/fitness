using System;
using System.Collections.Generic;
using Workouts.API.Interfaces;

namespace Workouts.API 
{
    public class WorkoutDefinition : IWorkoutDefinition
    {
        private List<string> exerciseNames = new List<string>
        {
            "Back Squat",
            "Bench Press",
            "Deadlift",
            "Bench Dips",
            "Lateral Pull-downs",
            "Shoulder Press",
            "Lunges"
        };

        public List<string> GetWorkoutDefinition()
        {
            return this.exerciseNames;
        }

        public double GetNextWeight(string exerciseName, double weight)
        {
            // Validate inputs.
            throw new NotImplementedException();
        }
    }
}