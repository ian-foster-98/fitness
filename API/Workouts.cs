using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;

namespace Workouts.API
{
    public class Workouts
    {
        /// <summary>
        /// Returns a new workout based on the previous recorded workout data.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A new workout definition.</returns>
        public APIGatewayProxyResponse GetNextWorkout(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var clientConfig = new AmazonDynamoDBConfig();
            var client = new AmazonDynamoDBClient(clientConfig);            
            var dbContext = new DynamoDBContext(client);
            var config = new DynamoDBOperationConfig();
            
            var workoutDefinition = new WorkoutDefinition();
            var exerciseEventStore = new ExerciseEventStore(dbContext, config);
            var exerciseViewStore = new ExerciseViewStore(dbContext);
            var workoutServices = new WorkoutServices(workoutDefinition, exerciseEventStore, exerciseViewStore);

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(workoutServices.GetNextWorkout()),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }

        /// <summary>
        /// Update an existing workout with new information about the exercise performed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>HTTP code indicating status of request.</returns>
        public APIGatewayProxyResponse SaveExercise(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var clientConfig = new AmazonDynamoDBConfig();
            var client = new AmazonDynamoDBClient(clientConfig);            
            var dbContext = new DynamoDBContext(client);
            var config = new DynamoDBOperationConfig();
            
            var workoutDefinition = new WorkoutDefinition();
            var exerciseEventStore = new ExerciseEventStore(dbContext, config);
            var exerciseViewStore = new ExerciseViewStore(dbContext);
            var workoutServices = new WorkoutServices(workoutDefinition, exerciseEventStore, exerciseViewStore);

            Console.WriteLine(String.Format("Contents of request are {0}", request.Body));

//            workoutServices.SaveExercise();

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Called UpdateWorkout",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }

        /// <summary>
        /// Projects the latest weight value onto the view store after saving an exercise.
        /// </summary>
        /// <param name="request"></param>
        public void ProjectExercise(DynamoDBEvent request, ILambdaContext context)
        {

        }
    }
}
