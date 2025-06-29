namespace Domain.DTOs;

public class IPadUserOptionDto
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public int CurrentPreStartId { get; set; }
    public bool ShowCompletedJobs { get; set; }
}