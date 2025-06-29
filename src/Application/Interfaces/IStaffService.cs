using Domain.DTOs;

namespace Application.Interfaces;

public interface IStaffService
{
    Task<IEnumerable<StaffDto>> GetAllStaffAsync();
    Task<StaffDto?> GetStaffByIdAsync(int id);
    Task<StaffDto> CreateStaffAsync(CreateStaffDto dto);
    Task<StaffDto> UpdateStaffAsync(UpdateStaffDto dto);
    Task<bool> DeleteStaffAsync(int id);
    Task<bool> ChangePasswordAsync(ChangePasswordDto dto);
}