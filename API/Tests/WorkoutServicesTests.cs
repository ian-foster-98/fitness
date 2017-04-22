using System;
using Moq;
using Xunit;
using Workouts.API.Exceptions;
using Workouts.API.Interfaces;
using System.Collections.Generic;

namespace Workouts.API.Tests
{
    public class WorkoutServicesTests
    {
        private readonly IWorkoutServices workoutServices;

        public WorkoutServicesTests()
        {
            this.workoutServices = new WorkoutServices(new WorkoutDefinition(), 
                MockExerciseEventStore(), 
                MockExerciseViewStore());
        }

        private IExerciseEventStore MockExerciseEventStore()
        {
            var exerciseEventStore = new Mock<IExerciseEventStore>();
            exerciseEventStore.Setup<IList<Exercise>>(x => x.FindExerciseEventsByName("Bench Dips", 2))
                .Returns(new List<Exercise>()
                {
                    new Exercise() {
                        ExerciseName =  "Bench Dips",
                        DateOfExercise = DateTime.Now.Date.ToString(),
                        Weight = 5,
                        Success = true
                    }
                });
            exerciseEventStore.Setup<IList<Exercise>>(x => x.FindExerciseEventsByName("Deadlift", 2))
                .Returns(new List<Exercise>()
                {
                    new Exercise() {
                        ExerciseName =  "Deadlift",
                        DateOfExercise = DateTime.Now.Date.ToString(),
                        Weight = 30,
                        Success = true
                    },
                    new Exercise() {
                        ExerciseName =  "Deadlift",
                        DateOfExercise = DateTime.Now.Date.AddDays(-2).ToString(),
                        Weight = 27.5,
                        Success = true
                    }
                });
            exerciseEventStore.Setup<IList<Exercise>>(x => x.FindExerciseEventsByName("Lunges", 2))
                .Returns(new List<Exercise>()
                {
                    new Exercise() {
                        ExerciseName =  "Lunges",
                        DateOfExercise = DateTime.Now.Date.ToString(),
                        Weight = 27.5,
                        Success = true
                    },
                    new Exercise() {
                        ExerciseName =  "Lunges",
                        DateOfExercise = DateTime.Now.Date.AddDays(-2).ToString(),
                        Weight = 27.5,
                        Success = true
                    }
                });
            return exerciseEventStore.Object;
        }

        private IExerciseViewStore MockExerciseViewStore()
        {
            var exerciseViewStore = new Mock<IExerciseViewStore>();
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Back Squat")).Returns(47.5);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Bench Press")).Returns(40);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Deadlift")).Returns(60);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Bench Dips")).Returns(5);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Lateral Pull-downs")).Returns(45);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Shoulder Press")).Returns(30);
            exerciseViewStore.Setup<double>(x => x.GetNextWeight("Lunges")).Returns(10);
            return exerciseViewStore.Object;
        }

        [Fact]
        public void TestInvalidExerciseName()
        {
            Assert.Throws<ExcerciseNotFoundException>(() => this.workoutServices.SaveExercise(
                new Exercise() {
                    ExerciseName =  "Non-existant exercise name.",
                    DateOfExercise = DateTime.Now.Date.ToString(),
                    Weight = 10,
                    Success = true
                }
            ));
        }

        [Fact]
        public void TestInvalidDate()
        {
            Assert.Throws<ArgumentException>(() => this.workoutServices.SaveExercise(
                new Exercise() {
                    ExerciseName =  "Back Squat",
                    DateOfExercise = DateTime.Now.Date.AddDays(1).ToString(),
                    Weight = 10,
                    Success = true
                }
            ));
        }

        [Fact]
        public void TestInvalidWeight()
        {
            Assert.Throws<ArgumentException>(() => this.workoutServices.SaveExercise(
                new Exercise() {
                    ExerciseName =  "Back Squat",
                    DateOfExercise = DateTime.Now.Date.ToString(),
                    Weight = -1,
                    Success = true
                }
            ));
        }

//        [Fact]
        public void TestNonsenseDate()
        {
            Assert.Throws<FormatException>(() => this.workoutServices.SaveExercise(
                new Exercise() {
                    ExerciseName =  "Back Squat",
                    DateOfExercise = "Nonsense Date Value",
                    Weight = -1,
                    Success = true
                }
            ));
        }

        [Fact]
        public void TestGetNextWorkout()
        {
            var workout = this.workoutServices.GetNextWorkout();
            Assert.Equal(7, workout.Count);
            Assert.Equal(40, workout[1].Weight);
        }

        [Fact]
        public void TestProjectExercisesNoPrevious()
        {
            var exercise = new Exercise() {
                ExerciseName =  "Bench Dips",
                DateOfExercise = DateTime.Now.Date.ToString(),
                Weight = 5,
                Success = true
            };

            var nextWeight = this.workoutServices.ProjectExercise(exercise);
            Assert.Equal(5, nextWeight);
        }

        [Fact]
        public void TestProjectExerciseDifferentPrevious()
        {
            var exercise = new Exercise() {
                ExerciseName =  "Deadlift",
                DateOfExercise = DateTime.Now.Date.ToString(),
                Weight = 30,
                Success = true
            };

            var nextWeight = this.workoutServices.ProjectExercise(exercise);
            Assert.Equal(30, nextWeight);
        }

        [Fact]
        public void TestProjectExerciseSamePrevious()
        {
            var exercise = new Exercise() {
                ExerciseName =  "Lunges",
                DateOfExercise = DateTime.Now.Date.ToString(),
                Weight = 27.5,
                Success = true
            };

            var nextWeight = this.workoutServices.ProjectExercise(exercise);
            Assert.Equal(30, nextWeight);
        }
    }
}