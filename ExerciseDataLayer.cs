using System;
using System.Collections.Generic;

namespace Workouts
{
    public class ExerciseDataLayer : IExerciseDataLayer
    {
        // Reference to the data storage layer.

        public ExerciseDataLayer()
        {
        }

        IList<Exercise> IExerciseDataLayer.GetPreviousExercises(string ExerciseName)
        {
            throw new NotImplementedException();
        }

        void IExerciseDataLayer.UpdateExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}