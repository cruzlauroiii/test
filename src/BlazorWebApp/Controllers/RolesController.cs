using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.DTOs;

namespace BlazorWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDto>> GetById(int id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);
        if (role == null)
            return NotFound();
        return Ok(role);
    }

    [HttpPost]
    public async Task<ActionResult<RoleDto>> Create([FromBody] CreateRoleDto createDto)
    {
        var role = await _roleService.CreateRoleAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RoleDto>> Update(int id, [FromBody] UpdateRoleDto updateDto)
    {
        updateDto.Id = id; // Set the ID from the route
        var role = await _roleService.UpdateRoleAsync(updateDto);
        if (role == null)
            return NotFound();
        return Ok(role);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _roleService.DeleteRoleAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }

    [HttpPost("{roleId}/properties")]
    public async Task<ActionResult<RolePropertyDto>> CreateProperty(int roleId, [FromBody] CreateRolePropertyDto createDto)
    {
        var property = await _roleService.AddRolePropertyAsync(roleId, createDto);
        return Ok(property);
    }

    [HttpPut("{roleId}/properties/{propertyId}")]
    public async Task<ActionResult<RolePropertyDto>> UpdateProperty(int roleId, int propertyId, [FromBody] UpdateRolePropertyDto updateDto)
    {
        updateDto.Id = propertyId; // Set the ID from the route
        var property = await _roleService.UpdateRolePropertyAsync(updateDto);
        if (property == null)
            return NotFound();
        return Ok(property);
    }

    [HttpDelete("{roleId}/properties/{propertyId}")]
    public async Task<ActionResult> DeleteProperty(int roleId, int propertyId)
    {
        var success = await _roleService.DeleteRolePropertyAsync(propertyId);
        if (!success)
            return NotFound();
        return NoContent();
    }
}