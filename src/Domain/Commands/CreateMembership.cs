namespace Domain.Commands;

public class CreateMembership
{
    public int MemberId { get; set; }
    public int MembershipTypeId { get; set; }
    public bool? BcanApproveCharge { get; set; }
    public bool? BexportCanCancelFumigation { get; set; }
    public string? Cancelledreason { get; set; }
    public string? Comment { get; set; }
    public DateTime? DtExpire { get; set; }
    public DateTime? DtJoined { get; set; }
    public string? ElevatedMemberPassword { get; set; }
    public string? Memberpassword { get; set; }
    public string? MembershipNo { get; set; }
    public decimal? Membershipfee { get; set; }
    public string? MembershipStatus { get; set; }
}