namespace Domain.Entities;

public class Staff
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public string PrimaryCompany { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }
    
    public ICollection<StaffRole> StaffRoles { get; set; } = new List<StaffRole>();
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    public IPadUserOption? IPadUserOption { get; set; }
}
