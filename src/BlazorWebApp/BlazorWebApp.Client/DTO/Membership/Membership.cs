namespace BlazorWebApp.Client.DTO.Membership;

public class Membership
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