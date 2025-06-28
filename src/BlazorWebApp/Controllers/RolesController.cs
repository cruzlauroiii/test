using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs;
using Application.UseCases.Roles;

namespace BlazorWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RolesController : ControllerBase
{
    private readonly RoleService _roleService;

    public RolesController(RoleService roleService)
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
    public async Task<ActionResult<RoleDto>> Create(CreateRoleDto dto)
    {
        try
        {
            var role = await _roleService.CreateRoleAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RoleDto>> Update(int id, UpdateRoleDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        try
        {
            var role = await _roleService.UpdateRoleAsync(dto);
            return Ok(role);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _roleService.DeleteRoleAsync(id);
        if (!result)
            return NotFound();
        
        return NoContent();
    }

    [HttpPost("{id}/properties")]
    public async Task<ActionResult<RolePropertyDto>> AddProperty(int id, CreateRolePropertyDto dto)
    {
        try
        {
            var property = await _roleService.AddRolePropertyAsync(id, dto);
            return Ok(property);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("properties/{propertyId}")]
    public async Task<ActionResult<RolePropertyDto>> UpdateProperty(int propertyId, UpdateRolePropertyDto dto)
    {
        if (propertyId != dto.Id)
            return BadRequest("ID mismatch");

        try
        {
            var property = await _roleService.UpdateRolePropertyAsync(dto);
            return Ok(property);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpDelete("properties/{propertyId}")]
    public async Task<ActionResult> DeleteProperty(int propertyId)
    {
        var result = await _roleService.DeleteRolePropertyAsync(propertyId);
        if (!result)
            return NotFound();
        
        return NoContent();
    }
}