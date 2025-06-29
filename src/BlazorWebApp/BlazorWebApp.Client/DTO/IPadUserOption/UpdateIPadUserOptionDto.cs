namespace BlazorWebApp.Client.DTO.IPadUserOption;

public class UpdateIPadUserOptionDto
{
    public int IdiPadUserOption { get; set; }
    public int? IstaffId { get; set; }
    public bool? BshowCompletedJob { get; set; }
    public bool? BshowDayShiftJob { get; set; }
    public bool? BshowNightShiftJob { get; set; }
    public int? IcurrentPreStartId { get; set; }
}