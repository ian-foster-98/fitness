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
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Back Squat")).Returns(47.5);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Bench Press")).Returns(40);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Deadlift")).Returns(60);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Bench Dips")).Returns(5);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Lateral Pull-downs")).Returns(45);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Shoulder Press")).Returns(30);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Lunges")).Returns(10);
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

        [Fact]
        public void TestGetNextWorkout()
        {
            var workout = this.workoutServices.GetNextWorkout();
            Assert.Equal(7, workout.Count);
            Assert.Equal(40, workout[1].Weight);
        }
    }
}