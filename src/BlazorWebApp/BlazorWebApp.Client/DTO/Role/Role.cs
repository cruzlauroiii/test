namespace BlazorWebApp.Client.DTO.Role;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<RoleProperty> Properties { get; set; } = new();
}