using Microsoft.EntityFrameworkCore;
using Domain.BusinessObjects;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Data.Repositories.Internal;

public class StaffRepository : IStaffRepository
{
    private readonly ApplicationDbContext _context;

    public StaffRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Staff>> GetAllAsync()
    {
        return await _context.Staff
            .Include(s => s.StaffRoles)
            .ThenInclude(sr => sr.Role)
            .ToListAsync();
    }

    public async Task<Staff?> GetByIdAsync(int id)
    {
        return await _context.Staff
            .Include(s => s.StaffRoles)
            .ThenInclude(sr => sr.Role)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Staff?> GetByUsernameAsync(string username)
    {
        return await _context.Staff
            .Include(s => s.StaffRoles)
            .ThenInclude(sr => sr.Role)
            .FirstOrDefaultAsync(s => s.Username == username);
    }

    public async Task<Staff?> GetByStaffIdAsync(int staffId)
    {
        return await _context.Staff
            .Include(s => s.StaffRoles)
            .ThenInclude(sr => sr.Role)
            .FirstOrDefaultAsync(s => s.StaffId == staffId);
    }

    public async Task<Staff> CreateAsync(Staff staff)
    {
        _context.Staff.Add(staff);
        await _context.SaveChangesAsync();
        return staff;
    }

    public async Task<Staff> UpdateAsync(Staff staff)
    {
        _context.Staff.Update(staff);
        await _context.SaveChangesAsync();
        return staff;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var staff = await _context.Staff.FindAsync(id);
        if (staff == null)
            return false;

        _context.Staff.Remove(staff);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(string username)
    {
        return await _context.Staff.AnyAsync(s => s.Username == username);
    }

    public async Task<bool> ExistsByStaffIdAsync(int staffId)
    {
        return await _context.Staff.AnyAsync(s => s.StaffId == staffId);
    }
}

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles
            .Include(r => r.Properties)
            .ToListAsync();
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<Role?> GetByIdWithPropertiesAsync(int id)
    {
        return await _context.Roles
            .Include(r => r.Properties)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Role> CreateAsync(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task<Role> UpdateAsync(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
            return false;

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class RolePropertyRepository : IRolePropertyRepository
{
    private readonly ApplicationDbContext _context;

    public RolePropertyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoleProperty>> GetByRoleIdAsync(int roleId)
    {
        return await _context.RoleProperties
            .Where(rp => rp.RoleId == roleId)
            .ToListAsync();
    }

    public async Task<RoleProperty?> GetByIdAsync(int id)
    {
        return await _context.RoleProperties.FindAsync(id);
    }

    public async Task<RoleProperty?> GetByRoleIdAndKeyAsync(int roleId, string key)
    {
        return await _context.RoleProperties
            .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.Key == key);
    }

    public async Task<RoleProperty> CreateAsync(RoleProperty roleProperty)
    {
        _context.RoleProperties.Add(roleProperty);
        await _context.SaveChangesAsync();
        return roleProperty;
    }

    public async Task<RoleProperty> UpdateAsync(RoleProperty roleProperty)
    {
        roleProperty.UpdatedAt = DateTime.UtcNow;
        _context.RoleProperties.Update(roleProperty);
        await _context.SaveChangesAsync();
        return roleProperty;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var property = await _context.RoleProperties.FindAsync(id);
        if (property == null)
            return false;

        _context.RoleProperties.Remove(property);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByRoleIdAndKeyAsync(int roleId, string key)
    {
        var property = await GetByRoleIdAndKeyAsync(roleId, key);
        if (property == null)
            return false;

        _context.RoleProperties.Remove(property);
        await _context.SaveChangesAsync();
        return true;
    }
}