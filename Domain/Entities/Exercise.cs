using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Exercise
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public virtual List<Aliases>? Aliases { get; set; }   
        public Force? Force { get; set; }
        public Mechanic? Mechanic { get; set; }
        public string? Equipment { get; set; }
        public Level? Level { get; set; }
        public string? Category { get; set; }
        public virtual List<Instructions>? Instructions { get; set; }
        public virtual List<PrimaryMuscles>? PrimaryMuscles { get; set; }
        public virtual List<SecondaryMuscles>? SecondaryMuscles { get; set; }
        public string? Description { get; set; }
        public virtual List<Tips>? Tips { get; set; }
        public string? UrlVideo { get; set; }
        public string? UrlPhoto { get; set; }
        public string? UrlGif { get; set; }
    }

    public class Aliases
    {
        public int? Id { get; set; }
        public string? Alias { get; set; }

        public int? ExerciseId { get; set; }
        
        [JsonIgnore]
        public virtual Exercise? Exercise { get; set; }
    }

    public class Instructions
    {
        public int? Id { get; set; }
        public string? Instruction { get; set; }
        public int? ExerciseId { get; set; }

        [JsonIgnore]
        public virtual Exercise? Exercise { get; set; }
    }

    public class PrimaryMuscles
    {
        public int? Id { get; set; }
        public string? PrimaryMuscle { get; set; }
        public int? ExerciseId { get; set; }

        [JsonIgnore]
        public virtual Exercise? Exercise { get; set; }
    }

    public class SecondaryMuscles
    {
        public int? Id { get; set; }
        public string? SecondaryMuscle { get; set; }
        public int? ExerciseId { get; set; }

        [JsonIgnore]
        public virtual Exercise? Exercise { get; set; }
    }

    public class Tips
    {
        public int? Id { get; set; }
        public string? Tip { get; set; }
        public int? ExerciseId { get; set; }

        [JsonIgnore]
        public virtual Exercise? Exercise { get; set; }
    }
}
