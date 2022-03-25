using Newtonsoft.Json;

namespace ZoomMeeting.Entities
{
    public class Meeting
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }
    }
}
