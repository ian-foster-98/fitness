using System;

namespace Workouts.API.Exceptions
{
    public class InvalidWeightException: Exception
    {
        public InvalidWeightException()
        {
        }

        public InvalidWeightException(string message)
            : base(message)
        {
        }

        public InvalidWeightException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
