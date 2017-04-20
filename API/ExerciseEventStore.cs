using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Workouts.API.Interfaces;

namespace Workouts.API
{
    public class ExerciseEventStore : IExerciseEventStore
    {
        private readonly string tableName = "Exercise";
        private IDynamoDBContext context;
        private DynamoDBOperationConfig config;

        public ExerciseEventStore(IDynamoDBContext context, DynamoDBOperationConfig config)
        {
            this.context = context;
            this.config = config;
        }

        public async Task<IList<Exercise>> FindExerciseEventsByName(string exerciseName, int limit)
        {
            var search = context.QueryAsync<Exercise>(exerciseName);
            var exerciseList = new List<Exercise>();
            do
            {
                exerciseList = await search.GetNextSetAsync(default(System.Threading.CancellationToken));
            } while (!search.IsDone);
 
            return exerciseList;
        }

        public void AddExerciseEvent(Exercise exercise)
        {
            var task = context.SaveAsync<Exercise>(exercise);
            task.Wait();
        }
    }
}