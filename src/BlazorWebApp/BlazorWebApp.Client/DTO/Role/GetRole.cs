namespace BlazorWebApp.Client.DTO.Role;

public class RoleDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<RolePropertyDto> Properties { get; set; } = new();
}