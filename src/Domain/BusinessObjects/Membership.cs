namespace Domain.BusinessObjects;

public class Membership
{
    public int Id { get; set; }
    public string MembershipNo { get; set; } = string.Empty;
    public string MemberPassword { get; set; } = string.Empty;
    public int MemberId { get; set; } // Foreign key to contacts.id
    public string MembershipType { get; set; } = string.Empty;
    public int RemoteStaffId { get; set; } // Foreign key to staff.staffid
    public string Company { get; set; } = string.Empty;
    public string PrimaryCompany { get; set; } = string.Empty;
    public string CompanyGroup { get; set; } = string.Empty;
    public string MainLogoLocation { get; set; } = string.Empty;
    public string ReportLogoLocation { get; set; } = string.Empty;
    
    // Navigation properties
    public Staff Staff { get; set; } = null!;
    public Contact Contact { get; set; } = null!;
    public MembershipType MembershipTypeEntity { get; set; } = null!;
}