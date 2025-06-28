using Application.DTOs;

namespace Application.Interfaces.Services;

public interface IStaffService
{
    Task<IEnumerable<StaffDto>> GetAllStaffAsync();
    Task<StaffDto?> GetStaffByIdAsync(int id);
    Task<StaffDto?> GetStaffByUsernameAsync(string username);
    Task<StaffDto?> GetStaffByStaffIdAsync(int staffId);
    Task<StaffDto> CreateStaffAsync(CreateStaffDto createStaffDto);
    Task<StaffDto> UpdateStaffAsync(int id, UpdateStaffDto updateStaffDto);
    Task<bool> DeleteStaffAsync(int id);
    Task<bool> ExistsAsync(string username);
    Task<bool> ExistsByStaffIdAsync(int staffId);
    Task<bool> ChangePasswordAsync(int staffId, string newPassword);
    Task<List<string>> GetStaffRolesAsync(int staffId);
    Task<bool> AssignRoleAsync(int staffId, int roleId);
    Task<bool> RemoveRoleAsync(int staffId, int roleId);
}