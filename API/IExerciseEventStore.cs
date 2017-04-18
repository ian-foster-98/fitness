using System.Collections.Generic;
using Workouts.API;

namespace Workouts.API
{
    public interface IExerciseEventStore
    {
        IList<Exercise> FindExerciseEventsByName(string exerciseName);

        void AddExerciseEvent(Exercise exercise);
    }
}