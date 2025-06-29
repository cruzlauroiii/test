namespace Domain.Queries;

public class GetMembership
{
    public int? Id { get; set; }
    public int? MemberId { get; set; }
    public string? MembershipNo { get; set; }
    public string? MembershipStatus { get; set; }
}