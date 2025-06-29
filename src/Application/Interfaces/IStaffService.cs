using BlazorWebApp.Client.DTO.Staff;

namespace Application.Interfaces;

public interface IStaffService
{
    Task<IEnumerable<Staff>> GetAllStaffAsync();
    Task<Staff?> GetStaffByIdAsync(int id);
    Task<Staff> CreateStaffAsync(CreateStaff dto);
    Task<Staff> UpdateStaffAsync(UpdateStaff dto);
    Task<bool> DeleteStaffAsync(int id);
    Task<bool> ChangePasswordAsync(ChangePassword dto);
}