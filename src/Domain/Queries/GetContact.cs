namespace Domain.Queries;

public class GetContact
{
    public int? Id { get; set; }
    public string? Company { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public bool? Barchived { get; set; }
}