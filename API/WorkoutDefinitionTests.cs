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
    }
}
