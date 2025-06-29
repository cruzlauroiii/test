namespace Domain.DTOs;

public class GetContact
{
    public int Id { get; set; }
    public string AssignedCompany { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string CompanyGroup { get; set; } = string.Empty;
}