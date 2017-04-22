using System.Collections.Generic;

namespace Workouts.API.Interfaces
{
    public interface IWorkoutDefinition
    {
        List<string> GetWorkoutDefinition();

        double GetNextWeight(Exercise latestExercise, Exercise previousExercise);
    }
}
