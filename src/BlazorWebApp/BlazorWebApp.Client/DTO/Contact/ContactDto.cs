namespace BlazorWebApp.Client.DTO.Contact;

public class ContactDto
{
    public int Id { get; set; }
    public string? Company { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool? Barchived { get; set; }
    public string CompanyGroup { get; set; } = string.Empty;
    public string AssignedCompany { get; set; } = string.Empty;
    public string Defaultdoorsfacing { get; set; } = string.Empty;
    public bool Ffeligible { get; set; }
    public Guid SguId { get; set; }
    public int IclientInvoiceValIdationDay { get; set; }
}