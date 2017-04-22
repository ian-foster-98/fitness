using System.Collections.Generic;

namespace Workouts.API.Interfaces
{
    public interface IWorkoutServices
    {
        List<Exercise> GetNextWorkout();

        void SaveExercise(Exercise exercise);

        double ProjectExercise(Exercise exercise);
    }
}