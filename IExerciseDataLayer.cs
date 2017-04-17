using System.Collections.Generic;

namespace Workouts
{
    public interface IExerciseDataLayer
    {
        IList<Exercise> GetPreviousExercises(string ExerciseName);

        void UpdateExercise(Exercise exercise);
    }
}