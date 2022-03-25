using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleApp3
{
    public class ZoomManager
    {
        private const string token = "eyJhbGciOiJIUzUxMiIsInYiOiIyLjAiLCJraWQiOiI0YmE1MTc1My1mZWM4LTQ4NDctODg0YS1hMWZlMzM3ODlkM2YifQ.eyJ2ZXIiOjcsImF1aWQiOiIyOWIyNjA4NTliM2Q2NWU4MDliNWNlNmMxZmJjNzc5MiIsImNvZGUiOiJrd3p0NXNNZ3l2X2M2VVdFLVByUzhTOUtmaURFR291ZXciLCJpc3MiOiJ6bTpjaWQ6XzVoYzJWZXBTalN3RTFESkdCRGl3IiwiZ25vIjowLCJ0eXBlIjowLCJ0aWQiOjAsImF1ZCI6Imh0dHBzOi8vb2F1dGguem9vbS51cyIsInVpZCI6ImM2VVdFLVByUzhTOUtmaURFR291ZXciLCJuYmYiOjE2NDgxOTA0NTIsImV4cCI6MTY0ODE5NDA1MiwiaWF0IjoxNjQ4MTkwNDUyLCJhaWQiOiJUbGlWb1dLVVJudWIzLTh4djRoSlBnIiwianRpIjoiNGUwNDE5OWYtMGZjOC00YTFmLTgwNzItMGNhYjZkOWI1ZGQ3In0.8_NtPo1kDERa3mW6tx9K1yR1UscxBL-R1fdnVYz2TRR-ZpDqKhvr3N_pdlSUQH6x1fIl3ekdrlykuVUEkBnKQA";

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
