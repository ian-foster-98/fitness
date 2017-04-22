using Xunit;
using Workouts.API.Exceptions;
using Workouts.API.Interfaces;
using System;

namespace Workouts.API.Tests
{
    public class WorkoutDefinitionTests
    {
        private readonly IWorkoutDefinition workoutDefinition;

        public WorkoutDefinitionTests()
        {
            this.workoutDefinition = new WorkoutDefinition();
        }

        [Fact]
        public void TestGetWorkoutDefinition()
        {
            var workout = this.workoutDefinition.GetWorkoutDefinition();
            Assert.Equal(7, workout.Count);
            Assert.Equal("Back Squat", workout[0]);
        }

        [Fact]
        public void TestProjectExerciseNoPrevious()
        {
            var exercise = new Exercise() {
                ExerciseName =  "Bench Dips",
                DateOfExercise = DateTime.Now.Date.ToString(),
                Weight = 5,
                Success = true
            };

            var nextWeight = this.workoutDefinition.GetNextWeight(exercise, null);
            Assert.Equal(5, nextWeight);
        }

        [Fact]
        public void TestProjectExerciseDifferentPrevious()
        {
            var exercise = new Exercise() {
                ExerciseName =  "Deadlift",
                DateOfExercise = DateTime.Now.Date.ToString(),
                Weight = 30,
                Success = true
            };

            var previousExercise = new Exercise() {
                ExerciseName =  "Deadlift",
                DateOfExercise = DateTime.Now.Date.AddDays(-2).ToString(),
                Weight = 27.5,
                Success = true
            };

            var nextWeight = this.workoutDefinition.GetNextWeight(exercise, previousExercise);
            Assert.Equal(30, nextWeight);
        }

        [Fact]
        public void TestProjectExerciseSamePrevious()
        {
            var exercise = new Exercise() {
                ExerciseName =  "Lunges",
                DateOfExercise = DateTime.Now.Date.ToString(),
                Weight = 27.5,
                Success = true
            };

            var previousExercise = new Exercise() {
                ExerciseName =  "Lunges",
                DateOfExercise = DateTime.Now.Date.AddDays(-2).ToString(),
                Weight = 27.5,
                Success = true
            };

            var nextWeight = this.workoutDefinition.GetNextWeight(exercise, previousExercise);
            Assert.Equal(30, nextWeight);
        }
    }
}
