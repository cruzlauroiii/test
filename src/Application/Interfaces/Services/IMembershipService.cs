using Application.DTOs;

namespace Application.Interfaces.Services;

public interface IMembershipService
{
    Task<IEnumerable<MembershipDto>> GetAllMembershipsAsync();
    Task<MembershipDto?> GetMembershipByIdAsync(int id);
    Task<IEnumerable<MembershipDto>> GetMembershipsByStaffIdAsync(int staffId);
    Task<MembershipDto> CreateMembershipAsync(CreateMembershipDto createMembershipDto);
    Task<MembershipDto> UpdateMembershipAsync(int id, UpdateMembershipDto updateMembershipDto);
    Task<bool> DeleteMembershipAsync(int id);
}