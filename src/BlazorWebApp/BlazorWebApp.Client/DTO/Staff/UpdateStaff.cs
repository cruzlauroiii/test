namespace BlazorWebApp.Client.DTO.Staff;

public class UpdateStaff
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public string PrimaryCompany { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<int> RoleIds { get; set; } = new();
}