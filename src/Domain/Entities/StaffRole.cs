namespace Domain.Entities;

public class StaffRole
{
    public int StaffId { get; set; }
    public Staff Staff { get; set; } = null!;
    
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}