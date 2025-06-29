namespace Domain.BusinessObjects;

public class StaffModule
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public string ModuleName { get; set; } = string.Empty;
    public bool IsEnabled { get; set; }
    
    // Navigation properties
    public Staff Staff { get; set; } = default!;
}