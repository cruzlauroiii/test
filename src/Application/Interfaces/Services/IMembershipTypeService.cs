using Application.DTOs;

namespace Application.Interfaces.Services;

public interface IMembershipTypeService
{
    Task<IEnumerable<MembershipTypeDto>> GetAllMembershipTypesAsync();
    Task<MembershipTypeDto?> GetMembershipTypeByIdAsync(int id);
    Task<IEnumerable<MembershipTypeDto>> GetMembershipTypesByStaffIdAsync(int staffId);
    Task<MembershipTypeDto> CreateMembershipTypeAsync(CreateMembershipTypeDto createMembershipTypeDto);
    Task<MembershipTypeDto> UpdateMembershipTypeAsync(int id, UpdateMembershipTypeDto updateMembershipTypeDto);
    Task<bool> DeleteMembershipTypeAsync(int id);
}