using Aplication.DTOs;
using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System.Text.Json;

namespace Aplication.Services
{
    public class ExerciseService(IExerciseRepository exerciseRepository) : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository = exerciseRepository;
        public async Task<IEnumerable<ExerciseDTO>?> GetApiExercises()
        {
            var muscle = "biceps";
            var jsonString = await _exerciseRepository.GetApiAsync(muscle);
            var response = JsonSerializer.Deserialize<List<ExerciseDTO>>(jsonString);

            return response;
        }

        public async Task<IEnumerable<ExerciseJsonDTO>?> GetJsonFileExercises()
        {
            var url = @"C:\Users\Gustavo Fonollosa\Desktop\MyroutineApp\exercises.json";
            var jsonString = await _exerciseRepository.GetJsonFile(url);
            if (jsonString == null)
            {
                return Enumerable.Empty<ExerciseJsonDTO>();
            }

            try
            {
                var exercisesString = JsonSerializer.Deserialize<List<ExerciseJsonModel>>(jsonString);
                var response = new List<ExerciseJsonDTO>();

                if (exercisesString == null)
                {
                    return response;
                }

                foreach (var item in exercisesString)
                {
                    response.Add(ExerciseMapper.JsonToDTO(item));
                }

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task FillDbWithExercises()
        {
            var exercisesFromJson = await this.GetJsonFileExercises();

            if (exercisesFromJson == null)
            {
                return;
            }

            // Hago la magia de conversion 
            foreach (var item in exercisesFromJson)
            {
                Exercise exercise = new()
                {
                    Name = item.Name,
                    Force = item.Force,
                    Mechanic = item.Mechanic,
                    Equipment = item.Equipment,
                    Level = item.Level,
                    Category = item.Category,
                    Description = item.Description,
                    Aliases = [],
                    Instructions = [],
                    PrimaryMuscles = [],
                    SecondaryMuscles = [],
                    Tips = [],
                };


                if (item.Aliases != null)
                {
                    foreach (var alias in item.Aliases)
                    {
                        exercise.Aliases.Add(new Aliases() { Alias = alias });
                    }
                }

                if (item.Instructions != null)
                {
                    foreach (var instr in item.Instructions)
                    {
                        exercise.Instructions.Add(new Instructions() { Instruction = instr });
                    }
                }

                if (item.PrimaryMuscles != null)
                {
                    foreach (var prMuscle in item.PrimaryMuscles)
                    {
                        exercise.PrimaryMuscles.Add(new PrimaryMuscles() { PrimaryMuscle = prMuscle });
                    }
                }

                if (item.SecondaryMuscles != null)
                {
                    foreach (var secMuscle in item.SecondaryMuscles)
                    {
                        exercise.SecondaryMuscles.Add(new SecondaryMuscles() { SecondaryMuscle = secMuscle });
                    }
                }

                if (item.Tips != null)
                {
                    foreach (var secMuscle in item.Tips)
                    {
                        exercise.Tips.Add(new Tips() { Tip = secMuscle });
                    }
                }

                await _exerciseRepository.AddAsync(exercise);
            }

        }

        public async Task<IEnumerable<ExerciseFullDTO>?> GetExercises(int page)
        {
            var exercises = (await _exerciseRepository.GetAsync(page))?.ToList();

            if (exercises == null || exercises.Count == 0)
            {
                return null;
            }

            var exerciseFullDTOs = exercises.Select(ExerciseMapper.ExerciseToDTO).ToList();         

            return exerciseFullDTOs;
        }

        public async Task<ExerciseFullDTO?> GetExerciseById(int id)
        {
            var exercise = await _exerciseRepository.GetExerciseAsync(id);
            if (exercise == null)
            {
                return null;
            }
            return ExerciseMapper.ExerciseToDTO(exercise);
        }

        public async Task<List<ExerciseFullDTO>?> GetListByMuscle(int page, string muscle)
        {
            var listOfMuscles = await _exerciseRepository.GetListByMuscle(page, muscle);

            if (listOfMuscles is null)
            {
                return null;
            }

            var response = new List<ExerciseFullDTO>();

            foreach (var item in listOfMuscles)
            {
                response.Add(ExerciseMapper.ExerciseToDTO(item));
            }

            return response;

        }

        public async Task<List<string>?> GetPrimaryMusclesList()
        {
            var primaryMuscles = await _exerciseRepository.GetPrimaryMusclesList();

            if (primaryMuscles == null)
            {
                return null;
            }

            return primaryMuscles;
        }
    }
}
