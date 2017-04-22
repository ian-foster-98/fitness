using Workouts.API.Interfaces;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Xunit;

namespace Workouts.API.Tests
{
    public class ExerciseViewStoreTests
    {
        private readonly AmazonDynamoDBClient client;
        private readonly IExerciseViewStore exerciseViewStore;

        public ExerciseViewStoreTests()
        {
            var clientConfig = new AmazonDynamoDBConfig();
            this.client = new AmazonDynamoDBClient(clientConfig);            
            var dbContext = new DynamoDBContext(client);
            this.exerciseViewStore = new ExerciseViewStore(dbContext);
        }

        [Fact]
        public void TestSetNextWeight()
        {
            var exerciseName = "Deadlift";
            var existingWeight = this.exerciseViewStore.GetNextWeight(exerciseName);
            Assert.Equal(0.0, existingWeight);

            this.exerciseViewStore.SetNextWeight(exerciseName, 55.0);
            var nextWeight = this.exerciseViewStore.GetNextWeight(exerciseName);
            Assert.Equal(55.0, nextWeight);
        }
    }
}
