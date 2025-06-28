using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Services;

public class MembershipTypeService : IMembershipTypeService
{
    private readonly IMembershipTypeRepository _membershipTypeRepository;

    public MembershipTypeService(IMembershipTypeRepository membershipTypeRepository)
    {
        _membershipTypeRepository = membershipTypeRepository;
    }

    public async Task<IEnumerable<MembershipType>> GetAllMembershipTypesAsync()
    {
        return await _membershipTypeRepository.GetAllAsync();
    }

    public async Task<MembershipType?> GetMembershipTypeByIdAsync(int id)
    {
        return await _membershipTypeRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<MembershipType>> GetMembershipTypesByStaffIdAsync(int staffId)
    {
        return await _membershipTypeRepository.GetByStaffIdAsync(staffId);
    }

    public async Task<MembershipType> CreateMembershipTypeAsync(MembershipType membershipType)
    {
        return await _membershipTypeRepository.CreateAsync(membershipType);
    }

    public async Task<MembershipType> UpdateMembershipTypeAsync(MembershipType membershipType)
    {
        return await _membershipTypeRepository.UpdateAsync(membershipType);
    }

    public async Task<bool> DeleteMembershipTypeAsync(int id)
    {
        return await _membershipTypeRepository.DeleteAsync(id);
    }
}