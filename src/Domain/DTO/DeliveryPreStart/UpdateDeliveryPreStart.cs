using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class UpdateDeliveryPreStartDto
{
    public int Id { get; set; }
    
    [Required]
    public int PreStartId { get; set; }
    
    [StringLength(100)]
    public string WorkCompany { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string TruckId { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string TrailerId { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string TrailerId2 { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string TrailerId3 { get; set; } = string.Empty;
}