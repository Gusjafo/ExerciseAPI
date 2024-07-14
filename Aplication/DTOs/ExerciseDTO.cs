using Domain.Enums;

namespace Aplication.DTOs
{
    public class ExerciseDTO
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public string? muscle { get; set; }
        public string? equipment { get; set; }
        public string? difficulty { get; set; }
        public string? instructions { get; set; }
    }
}
