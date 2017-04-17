namespace Workouts
{
    public interface IExerciseDataLayer
    {
        List<Exercise> GetPreviousExercises(string ExerciseName);
    }
}