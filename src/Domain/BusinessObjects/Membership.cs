namespace Domain.BusinessObjects;

public class Membership
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int MembershipTypeId { get; set; }
    public bool? BcanApproveCharge { get; set; }
    public bool? BexportCanCancelFumigation { get; set; }
    public string? Cancelledreason { get; set; }
    public string? Comment { get; set; }
    public DateTime? DtExpire { get; set; }
    public DateTime? DtJoined { get; set; }
    public string? ElevatedMemberPassword { get; set; }
    public DateTime? LwDateTime { get; set; }
    public string? LwSessionId { get; set; }
    public string? LwUserName { get; set; }
    public string? Memberpassword { get; set; }
    public string? MembershipNo { get; set; }
    public decimal? Membershipfee { get; set; }
    public string? MembershipStatus { get; set; }
    public int? Revision { get; set; }

    // Backwards compatibility properties
    public string MembershipType { get; set; } = string.Empty;
    public int RemoteStaffId { get; set; } // Foreign key to staff.staffid
    public string Company { get; set; } = string.Empty;
    public string PrimaryCompany { get; set; } = string.Empty;
    public string CompanyGroup { get; set; } = string.Empty;
    public string MainLogoLocation { get; set; } = string.Empty;
    public string ReportLogoLocation { get; set; } = string.Empty;
    
    // Property alias for MemberPassword
    public string MemberPassword 
    { 
        get => Memberpassword ?? string.Empty; 
        set => Memberpassword = value; 
    }
    
    // Navigation properties
    public Staff Staff { get; set; } = null!;
    public Contact Contact { get; set; } = null!;
    public MembershipType MembershipTypeEntity { get; set; } = null!;
}