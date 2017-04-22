using Amazon.DynamoDBv2.DataModel;

namespace Workouts.API
{
    [DynamoDBTable("TargetWeight")]
    public class TargetWeight
    {
        [DynamoDBHashKey]   
        public string ExerciseName{ get; set; }

        public double Weight { get; set; }
    }
}