namespace Domain.Entities;

public class RoleProperty
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    public Role Role { get; set; } = null!;
}