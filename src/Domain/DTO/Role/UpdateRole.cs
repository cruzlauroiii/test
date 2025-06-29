using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class UpdateRoleDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string Description { get; set; } = string.Empty;
    
    public List<RolePropertyDto> Properties { get; set; } = new();
}