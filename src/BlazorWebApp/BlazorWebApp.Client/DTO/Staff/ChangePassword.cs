namespace BlazorWebApp.Client.DTO.Staff;

public class ChangePassword
{
    public int StaffId { get; set; }
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}