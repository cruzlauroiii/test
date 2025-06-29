namespace BlazorWebApp.Client.DTO.IPadUserOption;

public class IPadUserOptionDto
{
    public int IdiPadUserOption { get; set; }
    public int? IstaffId { get; set; }
    public bool? BshowCompletedJob { get; set; }
    public bool? BshowDayShiftJob { get; set; }
    public bool? BshowNightShiftJob { get; set; }
    public int? IcurrentPreStartId { get; set; }

    // Backwards compatibility
    public int Id { get; set; }
    public int StaffId { get; set; }
    public bool ShowCompletedJobs { get; set; }
    public int CurrentPreStartId { get; set; }
}