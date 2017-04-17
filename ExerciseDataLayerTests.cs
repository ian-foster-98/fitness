using System;
using Xunit;

namespace Workouts
{
    public class ExerciseDataLayerTests
    {
        private readonly ExerciseDataLayer dataLayer;

        public ExerciseDataLayerTests()
        {
            this.dataLayer = new ExerciseDataLayer(null);
        }

        [Fact]
        public void TestInvalidExerciseName()
        {
            Assert.Throws<ArgumentException>(() => this.dataLayer.GetPreviousExercises("Non-existant exercise name."));
        }

        [Fact]
        public void TestNoExercisesRecorded()
        {
            var exercises = this.dataLayer.GetPreviousExercises("Back Squat");
            Assert.Empty(exercises);
        }

        [Fact]
        public void TestOneExercise()
        {
            var exerciseName = "Deadlift";
            var exercises = this.dataLayer.GetPreviousExercises(exerciseName);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].ExerciseName, exerciseName);
        }

        [Fact]
        public void TestTwoExercises()
        {
            var exercises = this.dataLayer.GetPreviousExercises("Lunges");
            Assert.Equal(exercises.Count, 2);
        }

        [Fact]
        public void TestCreateNewExercise()
        {
            var exerciseName = "Shoulder Press";
            var exercises = this.dataLayer.GetPreviousExercises(exerciseName);
            Assert.Empty(exercises);

            var newExercise = new Exercise()
            {
                ExerciseName = exerciseName,
                DateOfExercise = DateTime.UtcNow.Date.ToString(),
                Weight = 27.5,
                Success = true
            };
            this.dataLayer.UpdateExercise(newExercise);

            exercises = this.dataLayer.GetPreviousExercises(exerciseName);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].ExerciseName, exerciseName);
        }

        [Fact]
        public void TestUpdateExistingExercise()
        {
            var exerciseName = "Deadlift";
            var exercises = this.dataLayer.GetPreviousExercises(exerciseName);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].ExerciseName, exerciseName);
            Assert.Equal(exercises[0].Success, true);

            exercises[0].Success = false;
            this.dataLayer.UpdateExercise(exercises[0]);

            exercises = this.dataLayer.GetPreviousExercises(exerciseName);
            Assert.Single(exercises);
            Assert.Equal(exercises[0].Success, false);
        }
    }
}
