using System;
using Amazon.DynamoDBv2.DataModel;
using Workouts.API.Interfaces;

namespace Workouts.API
{
    public class ExerciseViewStore : IExerciseViewStore
    {
        // Reference to the data storage layer.
        private IDynamoDBContext context;

        public ExerciseViewStore(IDynamoDBContext context)
        {
            this.context = context;
        }

        public void SetNextWeight(string exerciseName, double weight)
        {
            throw new NotImplementedException();
        }

        public double GetNextWeight(string exerciseName)
        {
            throw new NotImplementedException();
        }
    }
}
