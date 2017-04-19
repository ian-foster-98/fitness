using System;
using Xunit;

namespace Workouts.API
{
    public class WorkoutDefinitionTests
    {
        private readonly IWorkoutDefinition workoutDefinition;

        public WorkoutDefinitionTests()
        {
            // TODO: Mock out DynamoDB client.
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
        public void TestNextWeightNegative()
        {
            Assert.Throws<InvalidWeightException>(() => this.workoutDefinition.GetNextWeight("", -1));
        }

        [Fact]
        public void TestZeroInput()
        {
            Assert.Throws<InvalidWeightException>(() => this.workoutDefinition.GetNextWeight("", 0));
        }

        [Fact]
        public void TestInvalidExerciseName()
        {
            Assert.Throws<ExcerciseNotFoundException>(() => this.workoutDefinition.GetNextWeight("", 0));
        }

        [Fact]
        public void TestInvalidWeightTwo()
        {
            Assert.Throws<ExcerciseNotFoundException>(() => this.workoutDefinition.GetNextWeight("", 3));
        }

        [Fact]
        public void TestInvalidWeightFive() 
        {
            Assert.Throws<ExcerciseNotFoundException>(() => this.workoutDefinition.GetNextWeight("", 4));
        }

        [Fact]
        public void TestInputWithCeiling()
        {
            var nextWeight = this.workoutDefinition.GetNextWeight("", 15);
            Assert.Equal(17.5, nextWeight);
        }

        [Fact]
        public void TestInputUnderCrossover()
        {
            var nextWeight = this.workoutDefinition.GetNextWeight("", 40);
            Assert.Equal(42.5, nextWeight);
        }

        [Fact]
        public void TestInputOverCrossover()
        {
            var nextWeight = this.workoutDefinition.GetNextWeight("", 50);
            Assert.Equal(55, nextWeight);
        }

        [Fact]
        public void TestInputWithFloor()
        {
            var nextWeight = this.workoutDefinition.GetNextWeight("", 65);
            Assert.Equal(70, nextWeight);
        }
    }
}
