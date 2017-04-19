using System;
using System.Collections.Generic;
using System.Linq;

namespace Workouts.API 
{
    public class WorkoutDefinition : IWorkoutDefinition
    {
        enum WeightCategory { Twos, Fives };

        private Dictionary<string, WeightCategory> exerciseNames = new Dictionary<string, WeightCategory>
        {
            { "Back Squat", WeightCategory.Twos },
            { "Bench Press", WeightCategory.Twos },
            { "Deadlift", WeightCategory.Twos },
            { "Bench Dips", WeightCategory.Twos },
            { "Lateral Pull-downs", WeightCategory.Fives },
            { "Shoulder Press", WeightCategory.Twos },
            { "Lunges", WeightCategory.Fives }
        };

        public List<string> GetWorkoutDefinition()
        {
            return this.exerciseNames.Keys.ToList();
        }

        public double GetNextWeight(double weight)
        {
            throw new NotImplementedException();
        }
    }
}