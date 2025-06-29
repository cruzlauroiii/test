using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class CreateRolePropertyDto
{
    [Required]
    [StringLength(100)]
    public string Key { get; set; } = string.Empty;
    
    [Required]
    [StringLength(500)]
    public string Value { get; set; } = string.Empty;
}