using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class ContactDto
{
    public int Id { get; set; }
    public string AssignedCompany { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string CompanyGroup { get; set; } = string.Empty;
}

public class CreateContactDto
{
    [StringLength(100)]
    public string AssignedCompany { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string Company { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string CompanyGroup { get; set; } = string.Empty;
}

public class UpdateContactDto
{
    public int Id { get; set; }
    
    [StringLength(100)]
    public string AssignedCompany { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string Company { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string CompanyGroup { get; set; } = string.Empty;
}