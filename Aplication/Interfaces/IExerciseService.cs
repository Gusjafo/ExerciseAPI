using Aplication.DTOs;
using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IExerciseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Listado de exercisios desde API externa</returns>
        Task<IEnumerable<ExerciseDTO>?> GetApiExercises();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns>Listado de ejercicios desde BD</returns>
        Task<IEnumerable<ExerciseFullDTO>?> GetExercises(int page);

        Task<IEnumerable<ExerciseJsonDTO>?> GetJsonFileExercises();

        Task FillDbWithExercises();

        Task<ExerciseFullDTO?> GetExerciseById(int id);

        Task<List<ExerciseFullDTO>?> GetListByMuscle(int page, string muscle);

        Task<List<string>?> GetPrimaryMusclesList();
    }
}
