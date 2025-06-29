using Domain.Enums;

namespace Domain.BusinessObjects;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public ICollection<StaffRole> StaffRoles { get; set; } = new List<StaffRole>();
    public ICollection<RoleProperty> Properties { get; set; } = new List<RoleProperty>();
}