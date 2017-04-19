using System;
using Amazon.DynamoDBv2.DataModel;
using Xunit;
using Workouts.API.Interfaces;

namespace Workouts.API.Tests
{
    public class ExerciseEventStoreTests
    {
        private readonly IExerciseEventStore dataLayer;

        public ExerciseEventStoreTests()
        {
            var dbContext = SetUpDBContext();
            this.dataLayer = new ExerciseEventStore(dbContext);
        }

        private IDynamoDBContext SetUpDBContext(){
            return null;
        }

//        [Fact]
        public void TestNoExercisesRecorded()
        {
            var exercises = this.dataLayer.FindExerciseEventsByName("Back Squat");
            Assert.Empty(exercises);
        }

//        [Fact]
        public void TestOneExercise()
        {
            var exerciseName = "Deadlift";
            var exercises = this.dataLayer.FindExerciseEventsByName(exerciseName);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].ExerciseName, exerciseName);
        }

//        [Fact]
        public void TestTwoExercises()
        {
            var exercises = this.dataLayer.FindExerciseEventsByName("Lunges");
            Assert.Equal(exercises.Count, 2);
        }

//        [Fact]
        public void TestAddNewEvent()
        {
            var exerciseName = "Shoulder Press";
            var exercises = this.dataLayer.FindExerciseEventsByName(exerciseName);
            Assert.Empty(exercises);

            var newExercise = new Exercise()
            {
                ExerciseName = exerciseName,
                DateOfExercise = DateTime.UtcNow.Date.ToString(),
                Weight = 27.5,
                Success = true
            };
            this.dataLayer.AddExerciseEvent(newExercise);

            exercises = this.dataLayer.FindExerciseEventsByName(exerciseName);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].ExerciseName, exerciseName);
        }
    }
}
