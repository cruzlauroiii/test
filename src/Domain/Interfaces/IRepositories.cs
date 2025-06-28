using Domain.Entities;

namespace Domain.Interfaces;

public interface IStaffRepository
{
    Task<IEnumerable<Staff>> GetAllAsync();
    Task<Staff?> GetByIdAsync(int id);
    Task<Staff?> GetByUsernameAsync(string username);
    Task<Staff> CreateAsync(Staff staff);
    Task<Staff> UpdateAsync(Staff staff);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(string username);
}

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role?> GetByIdAsync(int id);
    Task<Role?> GetByIdWithPropertiesAsync(int id);
    Task<Role> CreateAsync(Role role);
    Task<Role> UpdateAsync(Role role);
    Task<bool> DeleteAsync(int id);
}

public interface IRolePropertyRepository
{
    Task<IEnumerable<RoleProperty>> GetByRoleIdAsync(int roleId);
    Task<RoleProperty?> GetByIdAsync(int id);
    Task<RoleProperty?> GetByRoleIdAndKeyAsync(int roleId, string key);
    Task<RoleProperty> CreateAsync(RoleProperty roleProperty);
    Task<RoleProperty> UpdateAsync(RoleProperty roleProperty);
    Task<bool> DeleteAsync(int id);
    Task<bool> DeleteByRoleIdAndKeyAsync(int roleId, string key);
}

public interface IAuthService
{
    Task<bool> AuthenticateAsync(string username, string password);
    Task<string> HashPasswordAsync(string password);
    Task<bool> VerifyPasswordAsync(string password, string hash);
    Task<string> GenerateTokenAsync(Staff staff);
}