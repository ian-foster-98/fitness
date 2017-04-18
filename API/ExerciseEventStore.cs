using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace Workouts.API
{
    public class ExerciseEventStore : IExerciseEventStore
    {
        // Reference to the data storage layer.
        private DynamoDBContext context;

        public ExerciseEventStore(DynamoDBContext context)
        {
            this.context = context;
        }

        public IList<Exercise> FindExerciseEventsByName(string ExerciseName)
        {
            throw new NotImplementedException();
        }

        public void AddExerciseEvent(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}