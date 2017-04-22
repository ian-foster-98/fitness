using System;
using Amazon.DynamoDBv2.DataModel;
using Xunit;
using Workouts.API.Interfaces;
using Amazon.DynamoDBv2;

namespace Workouts.API.Tests
{
    public class ExerciseEventStoreTests
    {
        private readonly AmazonDynamoDBClient client;
        private readonly IExerciseEventStore eventStore;

        public ExerciseEventStoreTests()
        {
            var clientConfig = new AmazonDynamoDBConfig();
            this.client = new AmazonDynamoDBClient(clientConfig);
            
            var dbContext = new DynamoDBContext(client);
            var config = new DynamoDBOperationConfig();

            this.eventStore = new ExerciseEventStore(dbContext, config);
        }


        [Fact]
        public void TestNoExercisesRecorded()
        {
            var exercises = this.eventStore.FindExerciseEventsByName("Back Squat", 2);
            Assert.Empty(exercises);
        }

        [Fact]
        public void TestOneExercise()
        {
            var exerciseName = "Deadlift";
            var exercises = this.eventStore.FindExerciseEventsByName(exerciseName, 2);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].ExerciseName, exerciseName);
        }

        [Fact]
        public void TestTwoExercises()
        {
            var exercises = this.eventStore.FindExerciseEventsByName("Lunges", 2);
            Assert.Equal(exercises.Count, 2);
        }

        [Fact]
        public void TestAddNewEvent()
        {
            var exerciseName = "Shoulder Press";
            var exercises = this.eventStore.FindExerciseEventsByName(exerciseName, 2);
            Assert.Empty(exercises);

            var newExercise = new Exercise()
            {
                ExerciseName = exerciseName,
                DateOfExercise = DateTime.UtcNow.Date.ToString(),
                Weight = 27.5,
                Success = true
            };
            this.eventStore.AddExerciseEvent(newExercise);

            exercises = this.eventStore.FindExerciseEventsByName(exerciseName, 2);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].ExerciseName, exerciseName);
        }
    }
}
