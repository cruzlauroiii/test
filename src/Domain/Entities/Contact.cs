namespace Domain.Entities;

public class Contact
{
    public int Id { get; set; }
    public string AssignedCompany { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string CompanyGroup { get; set; } = string.Empty;
    
    // Navigation properties
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    public AssociatedCompany? AssociatedCompany { get; set; }
}