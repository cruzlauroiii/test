using Domain.BusinessObjects;

namespace Domain.Queries;

public class GetStaff
{
    public int? Id { get; set; }
    public int? StaffId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool? IsActive { get; set; }
}