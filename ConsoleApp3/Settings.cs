using Newtonsoft.Json;

namespace ConsoleApp3
{
    public class Settings
    {
        [JsonProperty("host_video")]
        public bool HostVideo { get; set; }

        [JsonProperty("participant_video")]
        public bool ParticipantVideo { get; set; }

        [JsonProperty("join_before_host")]
        public bool JoinBeforeHost { get; set; }

        [JsonProperty("mute_upon_entry")]
        public bool MuteUponEntry { get; set; }

        [JsonProperty("watermark")]
        public bool Watermark { get; set; }

        [JsonProperty("audio")]
        public string Audio { get; set; }

        [JsonProperty("auto_recording")]
        public string AutoRecording { get; set; }
    }
}