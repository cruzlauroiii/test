namespace Domain.BusinessObjects;

public class MembershipType
{
    public int Id { get; set; }
    public string MembershipTypeName { get; set; } = string.Empty;
    public int RemoteStaffId { get; set; }
    
    // Navigation properties
    public Staff Staff { get; set; } = null!;
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}