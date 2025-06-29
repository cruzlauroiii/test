using Domain.BusinessObjects;

namespace Application.Interfaces;

public interface IMembershipTypeService
{
    Task<IEnumerable<MembershipType>> GetAllMembershipTypesAsync();
    Task<MembershipType?> GetMembershipTypeByIdAsync(int id);
    Task<IEnumerable<MembershipType>> GetMembershipTypesByStaffIdAsync(int staffId);
    Task<MembershipType> CreateMembershipTypeAsync(MembershipType membershipType);
    Task<MembershipType> UpdateMembershipTypeAsync(MembershipType membershipType);
    Task<bool> DeleteMembershipTypeAsync(int id);
}