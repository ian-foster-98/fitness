using System.Collections.Generic;

namespace Workouts
{
    public interface IWorkoutCalculationEngine
    {
        List<Exercise> GetNewWorkout();

        List<string> GetExerciseNames();
    }
}