using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Client.DTO.DeliveryPreStart;

public class CreateDeliveryPreStartDto
{
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