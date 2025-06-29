using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class CreateMembershipType
{
    [Required]
    [StringLength(50)]
    public string MembershipTypeName { get; set; } = string.Empty;
    
    [Required]
    public int RemoteStaffId { get; set; }
}