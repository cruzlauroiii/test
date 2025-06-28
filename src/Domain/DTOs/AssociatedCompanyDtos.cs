using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class AssociatedCompanyDto
{
    public int Id { get; set; }
    public string CompanyCode { get; set; } = string.Empty;
    public string MainLogoLocation { get; set; } = string.Empty;
    public string ReportLogoLocation { get; set; } = string.Empty;
}

public class CreateAssociatedCompanyDto
{
    [Required]
    [StringLength(50)]
    public string CompanyCode { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string MainLogoLocation { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string ReportLogoLocation { get; set; } = string.Empty;
}

public class UpdateAssociatedCompanyDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string CompanyCode { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string MainLogoLocation { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string ReportLogoLocation { get; set; } = string.Empty;
}