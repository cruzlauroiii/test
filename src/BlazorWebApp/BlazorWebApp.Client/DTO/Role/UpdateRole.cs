using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Client.DTO.Role;

public class UpdateRole
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string Description { get; set; } = string.Empty;
    
    public List<RoleProperty> Properties { get; set; } = new();
}