using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using ZoomMeeting.Abstract;
using ZoomMeeting.Entities;

namespace ZoomMeeting.Concrete
{
    public class MeetingManager : IMeetingService
    {
        private const string token = "eyJhbGciOiJIUzUxMiIsInYiOiIyLjAiLCJraWQiOiJjNDAxZjFiOC04NzY3LTRhYmQtOWZiOS01OWJlMzU2YjhjNTgifQ.eyJ2ZXIiOjcsImF1aWQiOiIyOWIyNjA4NTliM2Q2NWU4MDliNWNlNmMxZmJjNzc5MiIsImNvZGUiOiJVelNXbTVjUHljX2M2VVdFLVByUzhTOUtmaURFR291ZXciLCJpc3MiOiJ6bTpjaWQ6XzVoYzJWZXBTalN3RTFESkdCRGl3IiwiZ25vIjowLCJ0eXBlIjowLCJ0aWQiOjAsImF1ZCI6Imh0dHBzOi8vb2F1dGguem9vbS51cyIsInVpZCI6ImM2VVdFLVByUzhTOUtmaURFR291ZXciLCJuYmYiOjE2NDgxOTY2NDMsImV4cCI6MTY0ODIwMDI0MywiaWF0IjoxNjQ4MTk2NjQzLCJhaWQiOiJUbGlWb1dLVVJudWIzLTh4djRoSlBnIiwianRpIjoiZjYxMzIyNjctZWI4Ni00OWM3LWJhZDEtOGNmZjNhYmJlMzY0In0.byLJjtDun6Cluluo4hyCf3LbMzBQ7PLndmwh2FMK_XsQ76pNEf03RrCcmSipq1BjcuYzxPnugn1PTfDwwgT6aQ";

        private string url = "https://api.zoom.us/v2/users/ismailc8n@gmail.com/meetings";

        private AuthenticationHeaderValue authentication = new AuthenticationHeaderValue("Bearer", token);

        public async Task<List<Meeting>> GetMettings()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    request.Headers.Authorization = authentication;
                    var response = await httpClient.SendAsync(request);
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<MeettingResult>(content)?.Meetings ?? new List<Meeting>();
                }
            }
        }

        public async Task AddMeeting(Meeting meeting)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(meeting);
                httpClient.DefaultRequestHeaders.Authorization = authentication;
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(url, content);
            }
        }
    }
}
