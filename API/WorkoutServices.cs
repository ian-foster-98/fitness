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
            // Get list of exercises to add to this workout.
            var exercises = this.workoutDefinition.GetWorkoutDefinition();
            var result = new List<Exercise>();
            foreach(var e in exercises)
            {
                result.Add(new Exercise() 
                {
                    ExerciseName = e,
                    DateOfExercise = DateTime.Now.Date.ToString(),
                    Weight = this.viewStore.GetNextWeight(e),
                    Success = false
                });
            }
            return result;
        }

        public void SaveExercise(Exercise exercise)
        {
            if(!workoutDefinition.GetWorkoutDefinition().Contains(exercise.ExerciseName))
            {
                throw new ExcerciseNotFoundException(String.Format("Exercise {0} is not a valid exercise.", exercise.ExerciseName));
            }

            var dateOfExercise = DateTime.Parse(exercise.DateOfExercise);
            if(dateOfExercise > DateTime.Now.Date){
                throw new ArgumentException(String.Format("Exercise date {0} is invalid. Cannot be later than current date.", exercise.DateOfExercise));
            }

            if(exercise.Weight <= 0)
            {
                throw new ArgumentException(String.Format("Weight {0} is not a valid weight. Must be greater than zero.", exercise.Weight));
            }

            eventStore.AddExerciseEvent(exercise);
        }

        public double ProjectExercise(Exercise exercise)
        {
            Exercise lastExercise = null;
            var previousExercises = this.eventStore.FindExerciseEventsByName(exercise.ExerciseName, 2);

            if(previousExercises.Count > 1)
            {
                lastExercise = previousExercises[1];
            } 
            else 
            {
                lastExercise = exercise;
            }

            var nextWeight = this.workoutDefinition.GetNextWeight(exercise, lastExercise);
            this.viewStore.SetNextWeight(exercise.ExerciseName, nextWeight);

            return nextWeight;
        }
    }
}