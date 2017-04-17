using System;
using System.Collections.Generic;

namespace Workouts
{
    public class WorkoutCalculationEngine : IWorkoutCalculationEngine
    {
        private IExerciseDataLayer dataLayer;
        private List<string> exercisesForWorkout = new List<string> {
            "Back Squat",
            "Bench Press",
            "Deadlift",
            "Bench Dips",
            "Lunges",
            "Shoulder Press",
            "Lateral Pull-downs"
        };
        
        public WorkoutCalculationEngine(IExerciseDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        public List<string> GetExerciseNames()
        {
            return exercisesForWorkout;
        }

        public List<Exercise> GetNewWorkout()
        {
            throw new NotImplementedException();
        }
    }
}