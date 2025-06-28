using Domain.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Services.UseCases.Memberships;

public class MembershipService : IMembershipService
{
    private readonly IMembershipRepository _membershipRepository;
    private readonly IStaffRepository _staffRepository;
    private readonly IContactRepository _contactRepository;

    public MembershipService(
        IMembershipRepository membershipRepository,
        IStaffRepository staffRepository,
        IContactRepository contactRepository)
    {
        _membershipRepository = membershipRepository;
        _staffRepository = staffRepository;
        _contactRepository = contactRepository;
    }

    public async Task<IEnumerable<MembershipDto>> GetAllMembershipsAsync()
    {
        var memberships = await _membershipRepository.GetAllAsync();
        return memberships.Select(MapToDto);
    }

    public async Task<MembershipDto?> GetMembershipByIdAsync(int id)
    {
        var membership = await _membershipRepository.GetByIdAsync(id);
        return membership != null ? MapToDto(membership) : null;
    }

    public async Task<IEnumerable<MembershipDto>> GetMembershipsByStaffIdAsync(int staffId)
    {
        var memberships = await _membershipRepository.GetByStaffIdAsync(staffId);
        return memberships.Select(MapToDto);
    }

    public async Task<MembershipDto> CreateMembershipAsync(CreateMembershipDto dto)
    {
        var membership = new Membership
        {
            MembershipNo = dto.MembershipNo,
            MemberPassword = dto.MemberPassword,
            MemberId = dto.MemberId,
            MembershipType = dto.MembershipType,
            RemoteStaffId = dto.RemoteStaffId,
            Company = dto.Company,
            PrimaryCompany = dto.PrimaryCompany,
            CompanyGroup = dto.CompanyGroup,
            MainLogoLocation = dto.MainLogoLocation,
            ReportLogoLocation = dto.ReportLogoLocation
        };

        var createdMembership = await _membershipRepository.CreateAsync(membership);
        return MapToDto(createdMembership);
    }

    public async Task<MembershipDto> UpdateMembershipAsync(UpdateMembershipDto dto)
    {
        var membership = await _membershipRepository.GetByIdAsync(dto.Id);
        if (membership == null)
            throw new ArgumentException("Membership not found");

        membership.MembershipNo = dto.MembershipNo;
        membership.MemberPassword = dto.MemberPassword;
        membership.MemberId = dto.MemberId;
        membership.MembershipType = dto.MembershipType;
        membership.RemoteStaffId = dto.RemoteStaffId;
        membership.Company = dto.Company;
        membership.PrimaryCompany = dto.PrimaryCompany;
        membership.CompanyGroup = dto.CompanyGroup;
        membership.MainLogoLocation = dto.MainLogoLocation;
        membership.ReportLogoLocation = dto.ReportLogoLocation;

        var updatedMembership = await _membershipRepository.UpdateAsync(membership);
        return MapToDto(updatedMembership);
    }

    public async Task<bool> DeleteMembershipAsync(int id)
    {
        return await _membershipRepository.DeleteAsync(id);
    }

    private static MembershipDto MapToDto(Membership membership)
    {
        return new MembershipDto
        {
            Id = membership.Id,
            MembershipNo = membership.MembershipNo,
            MemberPassword = membership.MemberPassword,
            MemberId = membership.MemberId,
            MembershipType = membership.MembershipType,
            RemoteStaffId = membership.RemoteStaffId,
            Company = membership.Company,
            PrimaryCompany = membership.PrimaryCompany,
            CompanyGroup = membership.CompanyGroup,
            MainLogoLocation = membership.MainLogoLocation,
            ReportLogoLocation = membership.ReportLogoLocation
        };
    }
}