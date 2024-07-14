using Aplication.DTOs;
using Aplication.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController(IExerciseService exerciseService) : ControllerBase
    {
        private readonly IExerciseService _exerciseService = exerciseService;

        [HttpGet]
        public async Task<ActionResult<List<ExerciseDTO>?>> Get()
        {
            var response = await _exerciseService.GetApiExercises();

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("/fromJson")]
        public async Task<ActionResult<List<ExerciseJsonDTO>>> GetJson()
        {
            var response = await _exerciseService.GetJsonFileExercises();

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<List<ExerciseFullDTO>>> GetPaginated(int page)
        {
            var response = await _exerciseService.GetExercises(page);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("id/{exercise}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "exercise" })]
        public async Task<ActionResult<List<ExerciseFullDTO>>> GetExerciseById(int exercise)
        {
            var response = await _exerciseService.GetExerciseById(exercise);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("muscles/")]
        [ResponseCache(CacheProfileName = "Cache60sec")]
        public async Task<ActionResult<List<PrimaryMuscleDTO>>> GetPrimaryMuscles()
        {
            var response = await _exerciseService.GetPrimaryMusclesList();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("/{page}/muscles/{muscle}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "page", "muscle" })]
        public async Task<ActionResult<List<ExerciseFullDTO>>> GetListOfExercisesByMuscle(int page, string muscle)
        {
            var response = await _exerciseService.GetListByMuscle(page, muscle);

            return response != null ? Ok(response) : NotFound();
        }



        [HttpPost]
        public async Task<ActionResult> PostExercicesToDB()
        {
            await _exerciseService.FillDbWithExercises();
            return Ok();
        }

    }

}
