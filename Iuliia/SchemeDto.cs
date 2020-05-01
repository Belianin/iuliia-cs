using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Iuliia
{
    public class SchemeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        [JsonPropertyName("mapping")]
        public Dictionary<char, string> Mapping { get; set; } 
        [JsonPropertyName("prev_mapping")]
        public Dictionary<string, string> PreviousMapping { get; set; } 
        [JsonPropertyName("next_mapping")]
        public Dictionary<string, string> NextMapping { get; set; } 
        [JsonPropertyName("ending_mapping")]
        public Dictionary<string, string> EndingMapping { get; set; } 
        public string[][] Samples { get; set; }
    }
}