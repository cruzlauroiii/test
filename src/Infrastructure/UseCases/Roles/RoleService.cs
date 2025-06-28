using Domain.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.UseCases.Roles;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IRolePropertyRepository _rolePropertyRepository;

    public RoleService(IRoleRepository roleRepository, IRolePropertyRepository rolePropertyRepository)
    {
        _roleRepository = roleRepository;
        _rolePropertyRepository = rolePropertyRepository;
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _roleRepository.GetAllAsync();
        return roles.Select(MapToDto);
    }

    public async Task<RoleDto?> GetRoleByIdAsync(int id)
    {
        var role = await _roleRepository.GetByIdWithPropertiesAsync(id);
        return role != null ? MapToDto(role) : null;
    }

    public async Task<RoleDto> CreateRoleAsync(CreateRoleDto dto)
    {
        var role = new Role
        {
            Name = dto.Name,
            Description = dto.Description
        };

        var createdRole = await _roleRepository.CreateAsync(role);

        // Add properties
        foreach (var propDto in dto.Properties)
        {
            var property = new RoleProperty
            {
                RoleId = createdRole.Id,
                Key = propDto.Key,
                Value = propDto.Value
            };
            await _rolePropertyRepository.CreateAsync(property);
        }

        return await GetRoleByIdAsync(createdRole.Id) ?? throw new InvalidOperationException("Failed to retrieve created role");
    }

    public async Task<RoleDto> UpdateRoleAsync(UpdateRoleDto dto)
    {
        var existingRole = await _roleRepository.GetByIdWithPropertiesAsync(dto.Id);
        if (existingRole == null)
            throw new ArgumentException("Role not found", nameof(dto.Id));

        // Update role basic info
        existingRole.Name = dto.Name;
        existingRole.Description = dto.Description;
        await _roleRepository.UpdateAsync(existingRole);

        // Get current properties
        var currentProperties = await _rolePropertyRepository.GetByRoleIdAsync(dto.Id);
        var currentPropsDict = currentProperties.ToDictionary(p => p.Key, p => p);

        // Process property updates
        foreach (var propDto in dto.Properties)
        {
            if (propDto.Id == 0) // New property
            {
                var newProperty = new RoleProperty
                {
                    RoleId = dto.Id,
                    Key = propDto.Key,
                    Value = propDto.Value
                };
                await _rolePropertyRepository.CreateAsync(newProperty);
            }
            else // Update existing property
            {
                var existingProperty = await _rolePropertyRepository.GetByIdAsync(propDto.Id);
                if (existingProperty != null && existingProperty.RoleId == dto.Id)
                {
                    existingProperty.Key = propDto.Key;
                    existingProperty.Value = propDto.Value;
                    await _rolePropertyRepository.UpdateAsync(existingProperty);
                }
            }
            currentPropsDict.Remove(propDto.Key);
        }

        // Remove properties that are no longer in the update
        foreach (var removedProperty in currentPropsDict.Values)
        {
            await _rolePropertyRepository.DeleteAsync(removedProperty.Id);
        }

        return await GetRoleByIdAsync(dto.Id) ?? throw new InvalidOperationException("Failed to retrieve updated role");
    }

    public async Task<bool> DeleteRoleAsync(int id)
    {
        return await _roleRepository.DeleteAsync(id);
    }

    public async Task<RolePropertyDto> AddRolePropertyAsync(int roleId, CreateRolePropertyDto dto)
    {
        var role = await _roleRepository.GetByIdAsync(roleId);
        if (role == null)
            throw new ArgumentException("Role not found", nameof(roleId));

        var property = new RoleProperty
        {
            RoleId = roleId,
            Key = dto.Key,
            Value = dto.Value
        };

        var createdProperty = await _rolePropertyRepository.CreateAsync(property);
        return MapToPropertyDto(createdProperty);
    }

    public async Task<RolePropertyDto> UpdateRolePropertyAsync(UpdateRolePropertyDto dto)
    {
        var property = await _rolePropertyRepository.GetByIdAsync(dto.Id);
        if (property == null)
            throw new ArgumentException("Property not found", nameof(dto.Id));

        property.Key = dto.Key;
        property.Value = dto.Value;
        
        var updatedProperty = await _rolePropertyRepository.UpdateAsync(property);
        return MapToPropertyDto(updatedProperty);
    }

    public async Task<bool> DeleteRolePropertyAsync(int propertyId)
    {
        return await _rolePropertyRepository.DeleteAsync(propertyId);
    }

    private static RoleDto MapToDto(Role role)
    {
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,
            Properties = role.Properties.Select(MapToPropertyDto).ToList()
        };
    }

    private static RolePropertyDto MapToPropertyDto(RoleProperty property)
    {
        return new RolePropertyDto
        {
            Id = property.Id,
            RoleId = property.RoleId,
            Key = property.Key,
            Value = property.Value,
            CreatedAt = property.CreatedAt,
            UpdatedAt = property.UpdatedAt
        };
    }
}