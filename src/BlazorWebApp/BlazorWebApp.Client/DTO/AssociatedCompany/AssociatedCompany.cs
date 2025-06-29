namespace BlazorWebApp.Client.DTO.AssociatedCompany;

public class AssociatedCompany
{
    public int IdAssociatedCompany { get; set; }
    public string? ScompanyName { get; set; }
    public string? ScompanyCode { get; set; }
    public bool? Bactive { get; set; }
    public string? SmainLogoLocation { get; set; }
    public string? SreportLogoLocation { get; set; }
    public string? SprimaryCompany { get; set; }

    // Backwards compatibility
    public int Id { get; set; }
    public string CompanyCode { get; set; } = string.Empty;
    public string MainLogoLocation { get; set; } = string.Empty;
    public string ReportLogoLocation { get; set; } = string.Empty;
}