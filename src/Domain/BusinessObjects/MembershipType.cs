namespace Domain.BusinessObjects;

public class MembershipType
{
    public int Id { get; set; }
    public string MembershipTypeName { get; set; } = string.Empty;
    public int RemoteStaffId { get; set; } // Foreign key to staff.staffid
    
    // Navigation properties
    public Staff Staff { get; set; } = null!;
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}