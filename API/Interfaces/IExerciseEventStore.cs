using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workouts.API.Interfaces
{
    public interface IExerciseEventStore
    {
        Task<IList<Exercise>> FindExerciseEventsByName(string exerciseName, int limit);

        void AddExerciseEvent(Exercise exercise);
    }
}