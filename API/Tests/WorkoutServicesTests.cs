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
    }
}