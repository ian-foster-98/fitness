using System;
using System.Collections.Generic;

namespace Workouts.API
{
    public class WorkoutServices
    {
        private IExerciseEventStore dataLayer;
        private IExerciseViewStore viewStore;

        // Constructor. Pass in relevant dependancies.
        public WorkoutServices(IExerciseEventStore dataLayer, IExerciseViewStore viewStore)
        {
            this.dataLayer = dataLayer;
            this.viewStore = viewStore;
        }

        public List<Exercise> GetNextWorkout()
        {
            throw new NotImplementedException();
        }

        public void SaveExercise(Exercise exercise)
        {
            // Validate data input.

            // Verify exerice name is valid.

            // Verify date is valid.

            // Verify weight is valid.

            // Save exercise.

            throw new NotImplementedException();
        }

        public void ProjectExercise(Exercise exercise)
        {
            // Get last two exercises with this name

            // Calculate next weight

            // Set next weight in view store
            
            throw new NotImplementedException();
        }
    }
}