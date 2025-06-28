using Application.DTOs;

namespace Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    Task<RoleDto?> GetRoleByIdAsync(int id);
    Task<RoleDto> CreateRoleAsync(CreateRoleDto dto);
    Task<RoleDto> UpdateRoleAsync(UpdateRoleDto dto);
    Task<bool> DeleteRoleAsync(int id);
    Task<RolePropertyDto> AddRolePropertyAsync(int roleId, CreateRolePropertyDto dto);
    Task<RolePropertyDto> UpdateRolePropertyAsync(UpdateRolePropertyDto dto);
    Task<bool> DeleteRolePropertyAsync(int propertyId);
}