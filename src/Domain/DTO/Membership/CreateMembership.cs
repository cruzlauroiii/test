using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class CreateMembershipDto
{
    [Required]
    [StringLength(50)]
    public string MembershipNo { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string MemberPassword { get; set; } = string.Empty;
    
    [Required]
    public int MemberId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string MembershipType { get; set; } = string.Empty;
    
    [Required]
    public int RemoteStaffId { get; set; }
    
    [StringLength(100)]
    public string Company { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string PrimaryCompany { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string CompanyGroup { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string MainLogoLocation { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string ReportLogoLocation { get; set; } = string.Empty;
}