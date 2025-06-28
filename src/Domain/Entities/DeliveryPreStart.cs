namespace Domain.Entities;

public class DeliveryPreStart
{
    public int Id { get; set; }
    public int PreStartId { get; set; }
    public string WorkCompany { get; set; } = string.Empty;
    public string TruckId { get; set; } = string.Empty;
    public string TrailerId { get; set; } = string.Empty;
    public string TrailerId2 { get; set; } = string.Empty;
    public string TrailerId3 { get; set; } = string.Empty;
    
    // Navigation properties
    public ICollection<IPadUserOption> IPadUserOptions { get; set; } = new List<IPadUserOption>();
}