namespace Domain.Commands;

public class CreateContact
{
    public required string Defaultdoorsfacing { get; set; }
    public required bool Ffeligible { get; set; }
    public required Guid SguId { get; set; }
    public required int IclientInvoiceValIdationDay { get; set; }
    
    public string? Abn { get; set; }
    public string? Company { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool? Barchived { get; set; }
    public string? CompanyGroup { get; set; }
    public string? AssignedCompany { get; set; }
}