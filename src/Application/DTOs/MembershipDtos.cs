using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class MembershipDto
{
    public int Id { get; set; }
    public string MembershipNo { get; set; } = string.Empty;
    public string MemberPassword { get; set; } = string.Empty;
    public int MemberId { get; set; }
    public string MembershipType { get; set; } = string.Empty;
    public int RemoteStaffId { get; set; }
    public string Company { get; set; } = string.Empty;
    public string PrimaryCompany { get; set; } = string.Empty;
    public string CompanyGroup { get; set; } = string.Empty;
    public string MainLogoLocation { get; set; } = string.Empty;
    public string ReportLogoLocation { get; set; } = string.Empty;
}

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

public class UpdateMembershipDto
{
    public int Id { get; set; }
    
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