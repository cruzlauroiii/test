namespace Domain.BusinessObjects;

public class Staff
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public int? AccessLevel { get; set; }
    public string? AccountActive { get; set; }
    public string? AccountLocked { get; set; }
    public DateTime? AccountUnlockTime { get; set; }
    public int? AssociatedContactId { get; set; }
    public bool? BaqisAuth { get; set; }
    public bool? BhasMsic { get; set; }
    public bool? BisDgDriver { get; set; }
    public bool? BisManager { get; set; }
    public bool? BisMcDriver { get; set; }
    public bool? BisRailInducted { get; set; }
    public bool? BisSubBy { get; set; }
    public bool? BkioskStaff { get; set; }
    public bool? BpwdChangeReq { get; set; }
    public bool? BpwdNeverExpire { get; set; }
    public string? CexternalCode { get; set; }
    public string? CanAssignJob { get; set; }
    public int? CurrentDispatchId { get; set; }
    public int? CurrentLegId { get; set; }
    public decimal? DgpsLatitude { get; set; }
    public decimal? DgpsLongitude { get; set; }
    public string? DefaultRole { get; set; }
    public string? Department { get; set; }
    public DateTime? DtCurrentShiftStart { get; set; }
    public DateTime? DtDefinitivUpdated { get; set; }
    public DateTime? DtDgLastChecked { get; set; }
    public DateTime? DtGpsEvent { get; set; }
    public DateTime? DtGpsUpdated { get; set; }
    public DateTime? DtMcLastChecked { get; set; }
    public DateTime? DtMsicLastChecked { get; set; }
    public DateTime? DtPwdChanged { get; set; }
    public DateTime? DtPwdExpire { get; set; }
    public DateTime? DtRailInductedLastChecked { get; set; }
    public DateTime? DtStatusUpdated { get; set; }
    public DateTime? DtVisitorBookOnSite { get; set; }
    public string? EmailAddr { get; set; }
    public DateTime? Enddate { get; set; }
    public string? FullName { get; set; }
    public int? IcurrentDriverLegId { get; set; }
    public int? IcurrentPreStartId { get; set; }
    public decimal? IshiftCostRate { get; set; }
    public int? IshiftMinute { get; set; }
    public int? IshiftStartPreStartId { get; set; }
    public int? IvisitorBookStaffId { get; set; }
    public int? IdDepartment { get; set; }
    public string? Initial { get; set; }
    public bool? IsDriver { get; set; }
    public string? JobTitle { get; set; }
    public DateTime? LwDateTime { get; set; }
    public string? LwUserName { get; set; }
    public int? MobileDeviceId { get; set; }
    public string? Note { get; set; }
    public string? Password { get; set; }
    public string? PrimaryCompany { get; set; }
    public int? Revision { get; set; }
    public string? SaqisAuthNumber { get; set; }
    public string? ScurrentDriverStatus { get; set; }
    public string? SdefinitivEmployeeId { get; set; }
    public string? SdefinitivEmployeeNumber { get; set; }
    public string? SdriverPin { get; set; }
    public string? ShashedPassword { get; set; }
    public string? ShashedSpecialPassword { get; set; }
    public string? SshiftStatus { get; set; }
    public string? SvisitorBookKiosk { get; set; }
    public string? ShortName { get; set; }
    public string? StaffLeft { get; set; }
    public int? StaffTypeId { get; set; }
    public DateTime? StartDate { get; set; }
    public string? UserName { get; set; }

    // Backwards compatibility properties - use UserName as the primary property
    public string Username 
    { 
        get => UserName ?? string.Empty; 
        set => UserName = value; 
    }
    public string PasswordHash { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }
    
    // Navigation properties
    public StaffOption StaffOption { get; set; } = default!;
    public ICollection<StaffModule> StaffModules { get; } = new List<StaffModule>();
    public ICollection<StaffRole> StaffRoles { get; set; } = new List<StaffRole>();
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    public IPadUserOption? IPadUserOption { get; set; }
}
