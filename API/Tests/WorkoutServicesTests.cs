using System;
using Moq;
using Xunit;
using Workouts.API.Exceptions;
using Workouts.API.Interfaces;

namespace Workouts.API.Tests
{
    public class WorkoutServicesTests
    {
        private readonly IWorkoutServices workoutServices;

        public WorkoutServicesTests()
        {
            this.workoutServices = new WorkoutServices(new WorkoutDefinition(), 
                MockExerciseEventStore(), 
                MockExerciseViewStore());
        }

        private IExerciseEventStore MockExerciseEventStore()
        {
            var exerciseEventStore = new Mock<IExerciseEventStore>();
            return exerciseEventStore.Object;
        }

        private IExerciseViewStore MockExerciseViewStore()
        {
            var exerciseViewStore = new Mock<IExerciseViewStore>();
            return exerciseViewStore.Object;
        }

        [Fact]
        public void TestInvalidExerciseName()
        {
            Assert.Throws<ExcerciseNotFoundException>(() => this.workoutServices.SaveExercise(
                new Exercise() {
                    ExerciseName =  "Non-existant exercise name.",
                    DateOfExercise = DateTime.Now.Date.ToString(),
                    Weight = 10,
                    Success = true
                }
            ));
        }

        [Fact]
        public void TestInvalidDate()
        {
            Assert.Throws<ArgumentException>(() => this.workoutServices.SaveExercise(
                new Exercise() {
                    ExerciseName =  "Back Squat",
                    DateOfExercise = DateTime.Now.Date.AddDays(1).ToString(),
                    Weight = 10,
                    Success = true
                }
            ));
        }

        [Fact]
        public void TestInvalidWeight()
        {
            Assert.Throws<ArgumentException>(() => this.workoutServices.SaveExercise(
                new Exercise() {
                    ExerciseName =  "Back Squat",
                    DateOfExercise = DateTime.Now.Date.ToString(),
                    Weight = -1,
                    Success = true
                }
            ));
        }

        [Fact]
        public void TestNonsenseDate()
        {
            Assert.Throws<FormatException>(() => this.workoutServices.SaveExercise(
                new Exercise() {
                    ExerciseName =  "Back Squat",
                    DateOfExercise = "Nonsense Date Value",
                    Weight = -1,
                    Success = true
                }
            ));
        }
    }
}