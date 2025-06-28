using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.DTOs;

namespace BlazorWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffController : ControllerBase
{
    private readonly IStaffService _staffService;

    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StaffDto>>> GetAll()
    {
        var staff = await _staffService.GetAllStaffAsync();
        return Ok(staff);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StaffDto>> GetById(int id)
    {
        var staff = await _staffService.GetStaffByIdAsync(id);
        if (staff == null)
            return NotFound();
        return Ok(staff);
    }

    [HttpPost]
    public async Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)
    {
        var staff = await _staffService.CreateStaffAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<StaffDto>> Update(int id, [FromBody] UpdateStaffDto updateDto)
    {
        updateDto.Id = id; // Set the ID from the route
        var staff = await _staffService.UpdateStaffAsync(updateDto);
        if (staff == null)
            return NotFound();
        return Ok(staff);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _staffService.DeleteStaffAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }

    [HttpPost("{id}/change-password")]
    public async Task<ActionResult> ChangePassword(int id, [FromBody] ChangePasswordDto changePasswordDto)
    {
        changePasswordDto.StaffId = id; // Set the ID from the route
        var success = await _staffService.ChangePasswordAsync(changePasswordDto);
        if (!success)
            return BadRequest("Failed to change password");
        return Ok();
    }
}