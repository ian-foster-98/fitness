using System;
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

        public override string ToString()
        {
            return String.Format("ExerciseName = {0}. DateOfExercise = {1}. Weight = {2}. Success = {3}.",
                ExerciseName, DateOfExercise, Weight, Success);
        }
    }
}