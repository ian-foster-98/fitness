using Amazon.DynamoDBv2.DataModel;

namespace Workouts
{
    [DynamoDBTable("Exercise")]
    public class Exercise
    {
        [DynamoDBHashKey]   
        public string DateOfExercise { get; set; }

        [DynamoDBRangeKey]
        public string ExerciseName{ get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }
        
        public string Weight { get; set; }

        public bool Success { get; set; }
    }
}