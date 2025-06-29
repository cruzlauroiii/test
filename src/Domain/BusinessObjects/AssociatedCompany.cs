namespace Domain.BusinessObjects;

public class AssociatedCompany
{
    public required int IdAssociatedCompany { get; set; }
    public bool? Bactive { get; set; }
    public string? CompanyLogo { get; set; }
    public string? CompanyReportlogo { get; set; }
    public string? CredPrefix { get; set; }
    public string? CreditEmailLayOut { get; set; }
    public int? IaddressBook { get; set; }
    public int? IdFuelLevyCostCentre { get; set; }
    public string? InvPrefix { get; set; }
    public string? InvoiceEmailLayOut { get; set; }
    public string? MsgFooter { get; set; }
    public string? MsgHeader { get; set; }
    public string? SaccountBsb { get; set; }
    public string? SaccountName { get; set; }
    public string? SaccountNumber { get; set; }
    public string? SbankName { get; set; }
    public string? ScompanyAbn { get; set; }
    public string? ScompanyAddress1 { get; set; }
    public string? ScompanyAddress2 { get; set; }
    public string? ScompanyAddress3 { get; set; }
    public string? ScompanyCode { get; set; }
    public string? ScompanyFax { get; set; }
    public string? ScompanyName { get; set; }
    public string? ScompanyPhone { get; set; }
    public string? ScompanyPostAddress1 { get; set; }
    public string? ScompanyPostAddress2 { get; set; }
    public string? ScompanyPostAddress3 { get; set; }
    public string? SmainLogoLocation { get; set; }
    public string? SpodLogoLocation { get; set; }
    public string? SprimaryCompany { get; set; }
    public string? SreportLogoLocation { get; set; }
    public string? SsmallLogoLocation { get; set; }

    // Backwards compatibility properties
    public int Id { get; set; }
    public string CompanyCode { get; set; } = string.Empty; // CompanyCode = isNull(Contacts.AssignedCompany, staff.primarycompany)
    public string MainLogoLocation { get; set; } = string.Empty;
    public string ReportLogoLocation { get; set; } = string.Empty;
    
    // Navigation properties
    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}