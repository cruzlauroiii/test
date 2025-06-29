using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class CreateContact
{
    [StringLength(100)]
    public string AssignedCompany { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string Company { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string CompanyGroup { get; set; } = string.Empty;
}