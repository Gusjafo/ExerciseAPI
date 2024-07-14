using System.Text.Json.Serialization;

namespace Aplication.DTOs
{
    public class ExerciseJsonModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("aliases")]
        public IEnumerable<string>? Aliases { get; set; }


        [JsonPropertyName("force")]
        public string? Force { get; set; }


        [JsonPropertyName("mechanic")]
        public string? Mechanic { get; set; }


        [JsonPropertyName("equipment")]
        public string? Equipment { get; set; }

        [JsonPropertyName("level")]
        public string? Level { get; set; }


        [JsonPropertyName("category")]
        public string? Category { get; set; }


        [JsonPropertyName("instructions")]
        public IEnumerable<string>? Instructions { get; set; }


        [JsonPropertyName("primaryMuscles")]
        public IEnumerable<string>? PrimaryMuscles { get; set; }

        [JsonPropertyName("secondaryMuscles")]
        public IEnumerable<string>? SecondaryMuscles { get; set; }


        [JsonPropertyName("description")]
        public string? Description { get; set; }


        [JsonPropertyName("tips")]
        public IEnumerable<string>? Tips { get; set; }
    }
}
