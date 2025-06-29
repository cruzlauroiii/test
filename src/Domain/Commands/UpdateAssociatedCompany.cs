namespace Domain.Commands;

public class UpdateAssociatedCompany
{
    public int IdAssociatedCompany { get; set; }
    public bool? Bactive { get; set; }
    public string? ScompanyName { get; set; }
    public string? ScompanyCode { get; set; }
    public string? SmainLogoLocation { get; set; }
    public string? SreportLogoLocation { get; set; }
    public string? SprimaryCompany { get; set; }
}