namespace BlazorWebApp.Client.DTO.DeliveryPreStart;

public class DeliveryPreStartDto
{
    public int Id { get; set; }
    public int PreStartId { get; set; }
    public string WorkCompany { get; set; } = string.Empty;
    public string TruckId { get; set; } = string.Empty;
    public string TrailerId { get; set; } = string.Empty;
    public string TrailerId2 { get; set; } = string.Empty;
    public string TrailerId3 { get; set; } = string.Empty;
}