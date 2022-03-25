using Newtonsoft.Json;

namespace ZoomMeeting.Entities
{
    public class MeettingResult
    {
        [JsonProperty("page_size")]
        public long PageSize { get; set; }

        [JsonProperty("total_records")]
        public long TotalRecords { get; set; }

        [JsonProperty("next_page_token")]
        public string NextPageToken { get; set; }

        [JsonProperty("meetings")]
        public List<Meeting> Meetings { get; set; }
    }
}
