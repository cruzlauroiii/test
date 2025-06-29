namespace Domain.BusinessObjects;

public class StaffOption
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    
    // Navigation properties
    public Staff Staff { get; set; } = default!;
}