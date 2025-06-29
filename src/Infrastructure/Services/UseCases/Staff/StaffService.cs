using Domain.DTOs;
using Application.Interfaces;
using Domain.BusinessObjects;
using Domain.Interfaces;

namespace Infrastructure.Services.UseCases.Staff;

public class StaffService : IStaffService
{
    private readonly IStaffRepository _staffRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IAuthService _authService;

    public StaffService(IStaffRepository staffRepository, IRoleRepository roleRepository, IAuthService authService)
    {
        _staffRepository = staffRepository;
        _roleRepository = roleRepository;
        _authService = authService;
    }

    public async Task<IEnumerable<StaffDto>> GetAllStaffAsync()
    {
        var staff = await _staffRepository.GetAllAsync();
        return staff.Select(MapToDto);
    }

    public async Task<StaffDto?> GetStaffByIdAsync(int id)
    {
        var staff = await _staffRepository.GetByIdAsync(id);
        return staff != null ? MapToDto(staff) : null;
    }

    public async Task<StaffDto> CreateStaffAsync(CreateStaffDto dto)
    {
        if (await _staffRepository.ExistsAsync(dto.Username))
            throw new InvalidOperationException("Username already exists");

        var passwordHash = await _authService.HashPasswordAsync(dto.Password);
        
        var staff = new Domain.BusinessObjects.Staff
        {
            Username = dto.Username,
            PasswordHash = passwordHash,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName
        };

        var createdStaff = await _staffRepository.CreateAsync(staff);
        
        // Assign roles
        foreach (var roleId in dto.RoleIds)
        {
            createdStaff.StaffRoles.Add(new StaffRole
            {
                StaffId = createdStaff.Id,
                RoleId = roleId
            });
        }

        await _staffRepository.UpdateAsync(createdStaff);
        return MapToDto(createdStaff);
    }

    public async Task<StaffDto> UpdateStaffAsync(UpdateStaffDto dto)
    {
        var staff = await _staffRepository.GetByIdAsync(dto.Id);
        if (staff == null)
            throw new InvalidOperationException("Staff not found");

        staff.Email = dto.Email;
        staff.FirstName = dto.FirstName;
        staff.LastName = dto.LastName;
        staff.IsActive = dto.IsActive;

        // Update roles
        staff.StaffRoles.Clear();
        foreach (var roleId in dto.RoleIds)
        {
            staff.StaffRoles.Add(new StaffRole
            {
                StaffId = staff.Id,
                RoleId = roleId
            });
        }

        var updatedStaff = await _staffRepository.UpdateAsync(staff);
        return MapToDto(updatedStaff);
    }

    public async Task<bool> DeleteStaffAsync(int id)
    {
        return await _staffRepository.DeleteAsync(id);
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
    {
        var staff = await _staffRepository.GetByIdAsync(dto.StaffId);
        if (staff == null)
            return false;

        if (!await _authService.VerifyPasswordAsync(dto.CurrentPassword, staff.PasswordHash))
            return false;

        staff.PasswordHash = await _authService.HashPasswordAsync(dto.NewPassword);
        await _staffRepository.UpdateAsync(staff);
        return true;
    }

    private static StaffDto MapToDto(Domain.BusinessObjects.Staff staff)
    {
        return new StaffDto
        {
            Id = staff.Id,
            Username = staff.Username,
            Email = staff.Email,
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            IsActive = staff.IsActive,
            CreatedAt = staff.CreatedAt,
            LastLoginAt = staff.LastLoginAt,
            Roles = staff.StaffRoles.Select(sr => sr.Role.Name).ToList()
        };
    }
}