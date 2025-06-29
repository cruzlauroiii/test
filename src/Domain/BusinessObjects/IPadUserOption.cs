namespace Domain.BusinessObjects;

public class IPadUserOption
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public int CurrentPreStartId { get; set; }
    public bool ShowCompletedJobs { get; set; }
    
    // Navigation properties
    public Staff Staff { get; set; } = null!;
    public DeliveryPreStart DeliveryPreStart { get; set; } = null!;
}