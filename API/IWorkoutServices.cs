using System.Collections.Generic;

namespace Workouts.API
{
    public interface IWorkoutServices
    {
        List<Exercise> GetNextWorkout();

        void SaveExercise(Exercise exercise);

        void ProjectExercise(Exercise exercise);
    }
}