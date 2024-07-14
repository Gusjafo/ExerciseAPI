using Domain.Enums;

namespace Aplication.DTOs
{
    public class ExerciseJsonDTO
    {
        public string? Name { get; set; }
       
        public IEnumerable<string>? Aliases { get; set; }

        public Force? Force { get; set; }

        public Mechanic? Mechanic { get; set; }

        public string? Equipment { get; set; }
        
        public Level? Level { get; set; }

        public string? Category { get; set; }

        public IEnumerable<string>? Instructions { get; set; }

        public IEnumerable<string>? PrimaryMuscles { get; set; }
              
        public IEnumerable<string>? SecondaryMuscles { get; set; }

        public string? Description { get; set; }

        public IEnumerable<string>? Tips { get; set; }
    }
}
