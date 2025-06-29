using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class UpdateMembershipTypeDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string MembershipTypeName { get; set; } = string.Empty;
    
    [Required]
    public int RemoteStaffId { get; set; }
}