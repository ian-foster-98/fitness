using System;

namespace Workouts.API.Exceptions
{
    public class ExcerciseNotFoundException: Exception
    {
        public ExcerciseNotFoundException()
        {
        }

        public ExcerciseNotFoundException(string message)
            : base(message)
        {
        }

        public ExcerciseNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}