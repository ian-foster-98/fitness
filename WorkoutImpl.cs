using System;
using System.Collections.Generic;

namespace Workouts
{
    public class WorkoutImpl
    {
        private IExerciseDataLayer dataLayer;
        private IWorkoutCalculationEngine calculationEngine;

        // Constructor. Pass in relevant dependancies.
        public WorkoutImpl(IExerciseDataLayer dataLayer, IWorkoutCalculationEngine calculationEngine)
        {
            this.dataLayer = dataLayer;
            this.calculationEngine = calculationEngine;
        }

        public List<Exercise> GetNewWorkout()
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkout(Exercise exercise)
        {
            // Validate data input.

            // Verify exerice name is valid.

            // Verify date is valid.

            // Verify weight is valid.

            // Save/update exercise.

            throw new NotImplementedException();
        }
    }
}