namespace BlazorWebApp.Client.DTO.Role;

public class RoleProperty
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}