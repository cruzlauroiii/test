using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs;
using Application.UseCases.Staff;

namespace BlazorWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StaffController : ControllerBase
{
    private readonly StaffService _staffService;

    public StaffController(StaffService staffService)
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
    public async Task<ActionResult<StaffDto>> Create(CreateStaffDto dto)
    {
        try
        {
            var staff = await _staffService.CreateStaffAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<StaffDto>> Update(int id, UpdateStaffDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        try
        {
            var staff = await _staffService.UpdateStaffAsync(dto);
            return Ok(staff);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _staffService.DeleteStaffAsync(id);
        if (!result)
            return NotFound();
        
        return NoContent();
    }

    [HttpPost("{id}/change-password")]
    public async Task<ActionResult> ChangePassword(int id, ChangePasswordDto dto)
    {
        if (id != dto.StaffId)
            return BadRequest("ID mismatch");

        var result = await _staffService.ChangePasswordAsync(dto);
        if (!result)
            return BadRequest("Invalid current password or staff not found");
        
        return Ok();
    }
}