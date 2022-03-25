using Microsoft.AspNetCore.Mvc;
using ZoomMeeting.Abstract;
using ZoomMeeting.Entities;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IMeetingService _meetingService;

        public HomeController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Callback()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> AddMeeting()
        {
            await _meetingService.AddMeeting(new Meeting()
            {
                Topic = "dotnet test zoom 3",
                Type = 2,
                StartTime = DateTime.Now.AddDays(27),
                Duration = "5",
                Settings = new Settings()
                {
                    HostVideo = true,
                    ParticipantVideo = true,
                    JoinBeforeHost = true,
                    MuteUponEntry = true,
                    Watermark = true,
                    Audio = "voip",
                    AutoRecording = "cloud"
                }
            });

            return "Toplantı Oluşturuldu";
        }
    }
}
