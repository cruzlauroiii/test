namespace BlazorWebApp.Client.DTO.MembershipType;

public class MembershipType
{
    public int Id { get; set; }
    public string MembershipTypeName { get; set; } = string.Empty;
    public int RemoteStaffId { get; set; }
}