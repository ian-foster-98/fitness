namespace Workouts.API.Interfaces
{
    public interface IExerciseViewStore
    {
        void SetNextWeight(string exerciseName, double weight);

        double GetNextWeight(string exerciseName);
    }
}