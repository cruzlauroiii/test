namespace Domain.DTOs;

public class ChangePasswordDto
{
    public int StaffId { get; set; }
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}