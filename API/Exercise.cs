using Amazon.DynamoDBv2.DataModel;

namespace Workouts.API
{
    [DynamoDBTable("Exercise")]
    public class Exercise
    {
        [DynamoDBHashKey]   
        public string DateOfExercise { get; set; }

        [DynamoDBRangeKey]
        public string ExerciseName{ get; set; }

        public double Weight { get; set; }

        public bool Success { get; set; }
    }
}