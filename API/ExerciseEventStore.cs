using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using Workouts.API.Interfaces;

namespace Workouts.API
{
    public class ExerciseEventStore : IExerciseEventStore
    {
        // Reference to the data storage layer.
        private IDynamoDBContext context;

        public ExerciseEventStore(IDynamoDBContext context)
        {
            this.context = context;
        }

        public IList<Exercise> FindExerciseEventsByName(string ExerciseName)
        {
            // Check name is valid.
            throw new NotImplementedException();
        }

        public void AddExerciseEvent(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}