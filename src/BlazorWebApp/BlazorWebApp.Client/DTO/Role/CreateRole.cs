using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Client.DTO.Role;

public class CreateRole
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string Description { get; set; } = string.Empty;
    
    public List<CreateRoleProperty> Properties { get; set; } = new();
}