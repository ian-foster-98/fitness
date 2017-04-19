using System.Collections.Generic;

namespace Workouts.API
{
    public interface IWorkoutDefinition
    {
        List<string> GetWorkoutDefinition();

        double GetNextWeight(double weight);
    }
}
