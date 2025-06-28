using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class IPadUserOptionDto
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public int CurrentPreStartId { get; set; }
    public bool ShowCompletedJobs { get; set; }
}

public class CreateIPadUserOptionDto
{
    [Required]
    public int StaffId { get; set; }
    
    [Required]
    public int CurrentPreStartId { get; set; }
    
    public bool ShowCompletedJobs { get; set; }
}

public class UpdateIPadUserOptionDto
{
    public int Id { get; set; }
    
    [Required]
    public int StaffId { get; set; }
    
    [Required]
    public int CurrentPreStartId { get; set; }
    
    public bool ShowCompletedJobs { get; set; }
}