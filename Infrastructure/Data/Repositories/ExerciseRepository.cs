using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ExerciseRepository(ExerciseContext context) : Repository<Exercise>(context), IExerciseRepository
    {
        public async Task<string> GetApiAsync(string muscle)
        {
            var url = $"https://api.api-ninjas.com/v1/exercises?muscle={muscle}";
            var uri = new Uri(url);
            var API_KEY = "TfHoYHuOnWWxOQvNZB6+wg==KDwpIdNxYZRliADU";
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = uri
                };
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("X-Api-Key", $"{API_KEY}");

                var response = await client.GetAsync(uri);

                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            catch (Exception err)
            {
                throw new Exception($"{err}");
            }            
        }

        public async Task<IEnumerable<Exercise>?> GetAsync(int page)
        {
            int pageSize = 10;

            var exercises = await context.Exercises.OrderBy(e => e.Id)
                                         .Skip((page - 1) * pageSize)
                                         .Take(pageSize)
                                         .Include(e => e.Aliases)
                                         .Include(e => e.Instructions)
                                         .Include(e => e.PrimaryMuscles)
                                         .Include(e => e.SecondaryMuscles)
                                         .Include(e => e.Tips)
                                         .ToListAsync();
            return exercises;
        }

        public async Task<Exercise?> GetExerciseAsync(int Id)
        {
            var exercises = await context.Exercises
                                         .Where(e => e.Id == Id)
                                         .Include(e => e.Aliases)
                                         .Include(e => e.Instructions)
                                         .Include(e => e.PrimaryMuscles)
                                         .Include(e => e.SecondaryMuscles)
                                         .Include(e => e.Tips).FirstOrDefaultAsync();
            return exercises;
        }

        public async Task<string?> GetJsonFile(string url)
        {
            try
            {
                using StreamReader fs = new(url);
                string response = await fs.ReadToEndAsync();
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }

        }

        public async Task<IEnumerable<Exercise>?> GetListByMuscle(int page, string muscle)
        {
            int pageSize = 10;

            var exercises = await context.Exercises
                                         .Where(e => e.PrimaryMuscles!.Any(pm => pm.PrimaryMuscle!.Contains(muscle)))
                                         .OrderBy(e => e)
                                         .Skip((page - 1) * pageSize)
                                         .Take(pageSize)              
                                         .Include(e => e.Aliases)
                                         .Include(e => e.Instructions)
                                         .Include(e => e.PrimaryMuscles)
                                         .Include(e => e.SecondaryMuscles)
                                         .Include(e => e.Tips)
                                         .ToListAsync();
            return exercises;
        }

        public async Task<List<string>?> GetPrimaryMusclesList()
        {
            var primaryMuscles = await context.PrimaryMuscles
                                              .Where(m => m.PrimaryMuscle != null)
                                              .Select(m => m.PrimaryMuscle!)
                                              .Distinct()
                                              .ToListAsync();

            return primaryMuscles.Count != 0 ? primaryMuscles : null;
        }
    }
}
