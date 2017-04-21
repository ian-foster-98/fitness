using Amazon.DynamoDBv2.DataModel;

namespace Workouts.API
{
    [DynamoDBTable("Exercise")]
    public class Exercise
    {
        [DynamoDBHashKey]   
        public string ExerciseName{ get; set; }

        [DynamoDBRangeKey]
        public string DateOfExercise { get; set; }

        public double Weight { get; set; }

        public bool Success { get; set; }
    }
}