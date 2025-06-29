namespace Domain.BusinessObjects;

public class IPadUserOption
{
    public int Id { get; set; }
    public int StaffId { get; set; } // Foreign key to staff.staffId
    public int CurrentPreStartId { get; set; } // Foreign key to DeliveryPreStart.PreStartId
    public bool ShowCompletedJobs { get; set; }
    
    // Navigation properties
    public Staff Staff { get; set; } = null!;
    public DeliveryPreStart? DeliveryPreStart { get; set; }
}