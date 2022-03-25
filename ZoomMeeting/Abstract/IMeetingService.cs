using ZoomMeeting.Entities;

namespace ZoomMeeting.Abstract
{
    public interface IMeetingService
    {
        Task<List<Meeting>> GetMettings();

        Task AddMeeting(Meeting meeting);
    }
}
