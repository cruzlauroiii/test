using BlazorWebApp.Client.DTO.Role;

namespace Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task<Role?> GetRoleByIdAsync(int id);
    Task<Role> CreateRoleAsync(CreateRole dto);
    Task<Role> UpdateRoleAsync(UpdateRole dto);
    Task<bool> DeleteRoleAsync(int id);
    Task<RoleProperty> AddRolePropertyAsync(int roleId, CreateRoleProperty dto);
    Task<RoleProperty> UpdateRolePropertyAsync(UpdateRoleProperty dto);
    Task<bool> DeleteRolePropertyAsync(int propertyId);
}