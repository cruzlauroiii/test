namespace Domain.DTOs;

public class MembershipTypeDto
{
    public int Id { get; set; }
    public string MembershipTypeName { get; set; } = string.Empty;
    public int RemoteStaffId { get; set; }
}