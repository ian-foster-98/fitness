using Amazon.DynamoDBv2.DataModel;
using Workouts.API.Interfaces;

namespace Workouts.API
{
    public class ExerciseViewStore : IExerciseViewStore
    {
        private IDynamoDBContext context;

        public ExerciseViewStore(IDynamoDBContext context)
        {
            this.context = context;
        }

        public void SetNextWeight(string exerciseName, double weight)
        {
            var targetWeight = new TargetWeight() 
            {
                ExerciseName = exerciseName,
                Weight = weight
            };
            var saveResult = context.SaveAsync(targetWeight);
            saveResult.Wait();
        }

        public double GetNextWeight(string exerciseName)
        {
            var item = context.LoadAsync<TargetWeight>(exerciseName);
            item.Wait();
            if(item.Result == null){
                return 0.0;
            }
            return item.Result.Weight;
        }
    }
}
