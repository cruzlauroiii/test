using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.DTOs;
using Domain.BusinessObjects;

namespace BlazorWebApp.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;

    public RolesController(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _roleRepository.GetAllAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        if (role == null)
            return NotFound();
        return Ok(role);
    }

    [HttpGet("{id}/properties")]
    public async Task<IActionResult> GetByIdWithProperties(int id)
    {
        var role = await _roleRepository.GetByIdWithPropertiesAsync(id);
        if (role == null)
            return NotFound();
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleDto roleDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var role = new Role
        {
            Name = roleDto.Name,
            Description = roleDto.Description
        };

        var createdRole = await _roleRepository.CreateAsync(role);
        return CreatedAtAction(nameof(GetById), new { id = createdRole.Id }, createdRole);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleDto roleDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingRole = await _roleRepository.GetByIdAsync(id);
        if (existingRole == null)
            return NotFound();

        existingRole.Name = roleDto.Name;
        existingRole.Description = roleDto.Description;

        var updatedRole = await _roleRepository.UpdateAsync(existingRole);
        return Ok(updatedRole);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _roleRepository.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}