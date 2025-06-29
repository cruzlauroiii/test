using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.DTOs;
using Domain.BusinessObjects;

namespace BlazorWebApp.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class StaffController : ControllerBase
{
    private readonly IStaffRepository _staffRepository;

    public StaffController(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var staff = await _staffRepository.GetAllAsync();
        return Ok(staff);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var staff = await _staffRepository.GetByIdAsync(id);
        if (staff == null)
            return NotFound();
        return Ok(staff);
    }

    [HttpGet("username/{username}")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var staff = await _staffRepository.GetByUsernameAsync(username);
        if (staff == null)
            return NotFound();
        return Ok(staff);
    }

    [HttpGet("staffid/{staffId}")]
    public async Task<IActionResult> GetByStaffId(int staffId)
    {
        var staff = await _staffRepository.GetByStaffIdAsync(staffId);
        if (staff == null)
            return NotFound();
        return Ok(staff);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStaffDto staffDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var staff = new Staff
        {
            StaffId = staffDto.StaffId,
            Username = staffDto.Username,
            Password = staffDto.Password,
            HashedPassword = staffDto.HashedPassword,
            PrimaryCompany = staffDto.PrimaryCompany,
            Email = staffDto.Email,
            FirstName = staffDto.FirstName,
            LastName = staffDto.LastName,
            IsActive = staffDto.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        var createdStaff = await _staffRepository.CreateAsync(staff);
        return CreatedAtAction(nameof(GetById), new { id = createdStaff.Id }, createdStaff);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStaffDto staffDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingStaff = await _staffRepository.GetByIdAsync(id);
        if (existingStaff == null)
            return NotFound();

        existingStaff.StaffId = staffDto.StaffId;
        existingStaff.Username = staffDto.Username;
        existingStaff.Password = staffDto.Password;
        existingStaff.HashedPassword = staffDto.HashedPassword;
        existingStaff.PrimaryCompany = staffDto.PrimaryCompany;
        existingStaff.Email = staffDto.Email;
        existingStaff.FirstName = staffDto.FirstName;
        existingStaff.LastName = staffDto.LastName;
        existingStaff.IsActive = staffDto.IsActive;

        var updatedStaff = await _staffRepository.UpdateAsync(existingStaff);
        return Ok(updatedStaff);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _staffRepository.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}