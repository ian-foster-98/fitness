using System;
using System.Collections.Generic;
using Workouts.API.Interfaces;
using Workouts.API.Exceptions;

namespace Workouts.API
{
    public class WorkoutServices : IWorkoutServices
    {
        private IWorkoutDefinition workoutDefinition;
        private IExerciseEventStore eventStore;
        private IExerciseViewStore viewStore;

        // Constructor. Pass in relevant dependancies.
        public WorkoutServices(IWorkoutDefinition workoutDefinition, 
            IExerciseEventStore eventStore, 
            IExerciseViewStore viewStore)
        {
            this.workoutDefinition = workoutDefinition;
            this.eventStore = eventStore;
            this.viewStore = viewStore;
        }

        public List<Exercise> GetNextWorkout()
        {
            throw new NotImplementedException();
        }

        public void SaveExercise(Exercise exercise)
        {
            // Verify exercise name is valid.
            if(!workoutDefinition.GetWorkoutDefinition().Contains(exercise.ExerciseName))
            {
                throw new ExcerciseNotFoundException(String.Format("Exercise {0} is not a valid exercise.", exercise.ExerciseName));
            }

            // Verify date is valid.
            var dateOfExercise = DateTime.Parse(exercise.DateOfExercise);
            if(dateOfExercise > DateTime.Now.Date){
                throw new ArgumentException(String.Format("Exercise date {0} is invalid. Cannot be later than current date.", exercise.DateOfExercise));
            }

            // Verify weight is valid.
            if(exercise.Weight <= 0)
            {
                throw new ArgumentException(String.Format("Weight {0} is not a valid weight. Must be greater than zero.", exercise.Weight));
            }

            // Save exercise.
            eventStore.AddExerciseEvent(exercise);
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