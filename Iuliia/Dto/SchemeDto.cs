using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Iuliia.Dto
{
    internal class SchemeDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("mapping")]
        public Dictionary<string, string> Mapping { get; set; } 
        [JsonPropertyName("prev_mapping")]
        public Dictionary<string, string> PreviousMapping { get; set; } 
        [JsonPropertyName("next_mapping")]
        public Dictionary<string, string> NextMapping { get; set; } 
        [JsonPropertyName("ending_mapping")]
        public Dictionary<string, string> EndingMapping { get; set; } 
        [JsonPropertyName("samples")]
        public string[][] Samples { get; set; }
    }
}