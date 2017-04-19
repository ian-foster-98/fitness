using System;
using System.Collections.Generic;
using Workouts.API.Interfaces;

namespace Workouts.API
{
    public class WorkoutServices : IWorkoutServices
    {
        private IWorkoutDefinition workoutDefinition;
        private IExerciseEventStore dataLayer;
        private IExerciseViewStore viewStore;

        // Constructor. Pass in relevant dependancies.
        public WorkoutServices(IWorkoutDefinition workoutDefinition, 
            IExerciseEventStore dataLayer, 
            IExerciseViewStore viewStore)
        {
            this.workoutDefinition = workoutDefinition;
            this.dataLayer = dataLayer;
            this.viewStore = viewStore;
        }

        public List<Exercise> GetNextWorkout()
        {
            throw new NotImplementedException();
        }

        public void SaveExercise(Exercise exercise)
        {
            // Verify exercise name is valid.

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