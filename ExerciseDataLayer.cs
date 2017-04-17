using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace Workouts
{
    public class ExerciseDataLayer : IExerciseDataLayer
    {
        // Reference to the data storage layer.
        private DynamoDBContext context;

        public ExerciseDataLayer(DynamoDBContext context)
        {
            this.context = context;
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