namespace Domain.BusinessObjects;

public class IPadUserOption
{
    public int IdiPadUserOption { get; set; }
    public bool? BshowCompletedJob { get; set; }
    public bool? BshowDayShiftJob { get; set; }
    public bool? BshowNightShiftJob { get; set; }
    public int? IstaffId { get; set; }
    public int? IcurrentPreStartId { get; set; }
    public DateTime? LwDateTime { get; set; }

    // Backwards compatibility properties
    public int Id { get; set; }
    public int StaffId { get; set; } // Foreign key to staff.staffId
    public int CurrentPreStartId { get; set; } // Foreign key to DeliveryPreStart.PreStartId
    public bool ShowCompletedJobs { get; set; }
    
    // Navigation properties
    public Staff Staff { get; set; } = null!;
    public DeliveryPreStart? DeliveryPreStart { get; set; }
}