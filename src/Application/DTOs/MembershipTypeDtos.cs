using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class MembershipTypeDto
{
    public int Id { get; set; }
    public string MembershipTypeName { get; set; } = string.Empty;
    public int RemoteStaffId { get; set; }
}

public class CreateMembershipTypeDto
{
    [Required]
    [StringLength(50)]
    public string MembershipTypeName { get; set; } = string.Empty;
    
    [Required]
    public int RemoteStaffId { get; set; }
}

public class UpdateMembershipTypeDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string MembershipTypeName { get; set; } = string.Empty;
    
    [Required]
    public int RemoteStaffId { get; set; }
}