using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Client.DTO.MembershipType;

public class UpdateMembershipType
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string MembershipTypeName { get; set; } = string.Empty;
    
    [Required]
    public int RemoteStaffId { get; set; }
}