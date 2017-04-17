using Xunit;

namespace Workouts
{
    public class WorkoutCalculationEngineTests
    {
        private readonly WorkoutCalculationEngine calculationEngine;

        public WorkoutCalculationEngineTests()
        {
            this.calculationEngine = new WorkoutCalculationEngine(null);
        }

        [Fact]
        public void TestGetExerciseNames()
        {
            var exerciseNames = this.calculationEngine.GetExerciseNames();
            Assert.Equal(exerciseNames.Count, 7);
            Assert.Contains<string>("Deadlift", exerciseNames);
        }
    }
}
