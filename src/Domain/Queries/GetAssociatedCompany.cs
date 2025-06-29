namespace Domain.Queries;

public class GetAssociatedCompany
{
    public int? IdAssociatedCompany { get; set; }
    public string? ScompanyName { get; set; }
    public string? ScompanyCode { get; set; }
    public bool? Bactive { get; set; }
}