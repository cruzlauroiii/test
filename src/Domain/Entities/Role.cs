namespace Domain.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public ICollection<StaffRole> StaffRoles { get; set; } = new List<StaffRole>();
    public ICollection<RoleProperty> Properties { get; set; } = new List<RoleProperty>();
}

public enum RoleType
{
    Broker = 1,
    Driver = 2,
    Forklift = 3,
    Fumigation = 4,
    Itv = 5
}