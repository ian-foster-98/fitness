using System;
using Amazon.DynamoDBv2.DataModel;
using Xunit;
using Workouts.API.Interfaces;
using Amazon.DynamoDBv2;

namespace Workouts.API.Tests
{
    public class ExerciseEventStoreTests
    {
        private readonly string tableName = "Exercise";
        private readonly AmazonDynamoDBClient client;
        private readonly IExerciseEventStore dataLayer;

        public ExerciseEventStoreTests()
        {
            var clientConfig = new AmazonDynamoDBConfig();
//            clientConfig.ServiceURL = "http://localhost:8000";
            this.client = new AmazonDynamoDBClient(clientConfig);
            
            var dbContext = new DynamoDBContext(client);
            var config = new DynamoDBOperationConfig();
            /*
             * Create table command line
             * aws dynamodb delete-table --endpoint-url http://localhost:8000 --table-name Exercise
             * aws dynamodb create-table --endpoint-url http://localhost:8000 --table-name Exercise --attribute-definitions AttributeName=DateOfExercise,AttributeType=S AttributeName=ExerciseName,AttributeType=S --key-schema AttributeName=DateOfExercise,KeyType=HASH AttributeName=ExerciseName,KeyType=RANGE --provisioned-throughput ReadCapacityUnits=5,WriteCapacityUnits=5
             * aws dynamodb batch-write-item --endpoint-url http://localhost:8000 --request-items file://API/Tests/test_items.json
            */

            this.dataLayer = new ExerciseEventStore(dbContext, config);
        }


        [Fact]
        public async void TestNoExercisesRecorded()
        {
            var exercises = await this.dataLayer.FindExerciseEventsByName("Back Squat", 2);
            Assert.Empty(exercises);
        }

        [Fact]
        public async void TestOneExercise()
        {
            var exerciseName = "Deadlift";
            var exercises = await this.dataLayer.FindExerciseEventsByName(exerciseName, 2);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].ExerciseName, exerciseName);
        }

        [Fact]
        public async void TestTwoExercises()
        {
            var exercises = await this.dataLayer.FindExerciseEventsByName("Lunges", 2);
            Assert.Equal(exercises.Count, 2);
        }

        [Fact]
        public async void TestAddNewEvent()
        {
            var exerciseName = "Shoulder Press";
            var exercises = await this.dataLayer.FindExerciseEventsByName(exerciseName, 2);
            Assert.Empty(exercises);

            var newExercise = new Exercise()
            {
                ExerciseName = exerciseName,
                DateOfExercise = DateTime.UtcNow.Date.ToString(),
                Weight = 27.5,
                Success = true
            };
            this.dataLayer.AddExerciseEvent(newExercise);

            exercises = await this.dataLayer.FindExerciseEventsByName(exerciseName, 2);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].ExerciseName, exerciseName);
        }
    }
}
