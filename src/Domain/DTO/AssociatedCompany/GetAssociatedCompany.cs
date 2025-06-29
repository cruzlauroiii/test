namespace Domain.DTOs;

public class AssociatedCompanyDto
{
    public int Id { get; set; }
    public string CompanyCode { get; set; } = string.Empty;
    public string MainLogoLocation { get; set; } = string.Empty;
    public string ReportLogoLocation { get; set; } = string.Empty;
}