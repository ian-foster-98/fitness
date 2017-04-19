using System.Collections.Generic;

namespace Workouts.API
{
    public interface IWorkoutDefinition
    {
        List<string> GetWorkoutDefinition();

        double GetNextWeight(string exerciseName, double weight);
    }
}
