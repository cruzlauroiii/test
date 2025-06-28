using Application.DTOs;

namespace Application.Interfaces;

public interface IMembershipService
{
    Task<IEnumerable<MembershipDto>> GetAllMembershipsAsync();
    Task<MembershipDto?> GetMembershipByIdAsync(int id);
    Task<IEnumerable<MembershipDto>> GetMembershipsByStaffIdAsync(int staffId);
    Task<MembershipDto> CreateMembershipAsync(CreateMembershipDto dto);
    Task<MembershipDto> UpdateMembershipAsync(UpdateMembershipDto dto);
    Task<bool> DeleteMembershipAsync(int id);
}