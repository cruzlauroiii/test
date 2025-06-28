using Application.DTOs;

namespace Application.Interfaces.Services;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    Task<RoleDto?> GetRoleByIdAsync(int id);
    Task<RoleDto?> GetRoleByIdWithPropertiesAsync(int id);
    Task<RoleDto> CreateRoleAsync(CreateRoleDto createRoleDto);
    Task<RoleDto> UpdateRoleAsync(int id, UpdateRoleDto updateRoleDto);
    Task<bool> DeleteRoleAsync(int id);
}