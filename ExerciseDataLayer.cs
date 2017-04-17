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

        public IList<Exercise> GetPreviousExercises(string ExerciseName)
        {
            // Validate incoming data.
            throw new NotImplementedException();
        }

        public void UpdateExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}