using System.Collections.Generic;
using System.Net;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

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
            context.Logger.LogLine("GetNextWorkout Request\n");

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Called GetNextWorkout",
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
            context.Logger.LogLine("Get Request\n");

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Called UpdateWorkout",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }
    }
}
