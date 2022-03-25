using ConsoleApp3;


var manager = new ZoomManager();


await manager.AddMeeting(new Meeting()
{
    Topic = "dotnet test zoom 2",
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


var list = await manager.GetMettings();

Console.WriteLine(list.Count);
