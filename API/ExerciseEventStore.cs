using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using Workouts.API.Interfaces;

namespace Workouts.API
{
    public class ExerciseEventStore : IExerciseEventStore
    {
        private IDynamoDBContext context;
        private DynamoDBOperationConfig config;

        public ExerciseEventStore(IDynamoDBContext context, DynamoDBOperationConfig config)
        {
            this.context = context;
            this.config = config;
        }

        public IList<Exercise> FindExerciseEventsByName(string exerciseName, int limit)
        {
            this.config.BackwardQuery = true;
            var search = context.QueryAsync<Exercise>(exerciseName, this.config);
            return search.GetNextSetAsync().Result;
        }

        public void AddExerciseEvent(Exercise exercise)
        {
            var task = context.SaveAsync<Exercise>(exercise);
            task.Wait();
        }
    }
}