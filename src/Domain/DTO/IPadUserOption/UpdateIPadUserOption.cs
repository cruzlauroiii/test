using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class UpdateIPadUserOptionDto
{
    public int Id { get; set; }
    
    [Required]
    public int StaffId { get; set; }
    
    [Required]
    public int CurrentPreStartId { get; set; }
    
    public bool ShowCompletedJobs { get; set; }
}