using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class ExerciseFullDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public List<string?>? Aliases { get; set; }
        public string? Force { get; set; }
        public string? Mechanic { get; set; }
        public string? Equipment { get; set; }
        public string? Level { get; set; }
        public string? Category { get; set; }
        public List<string?>? Instructions { get; set; }
        public List<string?>? PrimaryMuscles { get; set; }
        public List<string?>? SecondaryMuscles { get; set; }
        public string? Description { get; set; }
        public List<string?>? Tips { get; set; }
        public string? UrlVideo { get; set; }
        public string? UrlPhoto { get; set; }
        public string? UrlGif { get; set; }
    }
}
