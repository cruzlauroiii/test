using BlazorWebApp.Client.DTO.Membership;

namespace Application.Interfaces;

public interface IMembershipService
{
    Task<IEnumerable<Membership>> GetAllMembershipsAsync();
    Task<Membership?> GetMembershipByIdAsync(int id);
    Task<IEnumerable<Membership>> GetMembershipsByStaffIdAsync(int staffId);
    Task<Membership> CreateMembershipAsync(CreateMembership dto);
    Task<Membership> UpdateMembershipAsync(UpdateMembership dto);
    Task<bool> DeleteMembershipAsync(int id);
}