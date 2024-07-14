using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        Task<IEnumerable<Exercise>?> GetAsync(int page);
        Task<Exercise?> GetExerciseAsync(int Id);
        Task<string> GetApiAsync(string muscle);
        Task<string?> GetJsonFile(string url);

        Task<IEnumerable<Exercise>?> GetListByMuscle(int page, string muscle);

        Task<List<string>?> GetPrimaryMusclesList();
    }
}
