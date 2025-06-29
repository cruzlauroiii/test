namespace Domain.BusinessObjects;

public class AssociatedCompany
{
    public int Id { get; set; }
    public string CompanyCode { get; set; } = string.Empty; // CompanyCode = isNull(Contacts.AssignedCompany, staff.primarycompany)
    public string MainLogoLocation { get; set; } = string.Empty;
    public string ReportLogoLocation { get; set; } = string.Empty;
    
    // Navigation properties
    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}