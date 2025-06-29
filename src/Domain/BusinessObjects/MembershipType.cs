namespace Domain.BusinessObjects;

public class MembershipType
{
    public int Id { get; set; }
    public int MembershipTypeId { get; set; }
    public string? Active { get; set; }
    public string Company { get; set; } = string.Empty;
    public int? Membernolength { get; set; }
    public string? Membernoprefix { get; set; }
    public string? MembershipGroupId { get; set; }
    public string? MembershipName { get; set; }
    public int? RemoteStaffId { get; set; }
    public string? ShexColour { get; set; }

    // Backwards compatibility properties
    public string MembershipTypeName { get; set; } = string.Empty;
    
    // Navigation properties
    public Staff? Staff { get; set; }
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}