using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.DTOs;

namespace BlazorWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembershipsController : ControllerBase
{
    private readonly IMembershipService _membershipService;

    public MembershipsController(IMembershipService membershipService)
    {
        _membershipService = membershipService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MembershipDto>>> GetAll()
    {
        var memberships = await _membershipService.GetAllMembershipsAsync();
        return Ok(memberships);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MembershipDto>> GetById(int id)
    {
        var membership = await _membershipService.GetMembershipByIdAsync(id);
        if (membership == null)
            return NotFound();
        return Ok(membership);
    }

    [HttpGet("by-member/{memberId}")]
    public async Task<ActionResult<IEnumerable<MembershipDto>>> GetByMemberId(int memberId)
    {
        var memberships = await _membershipService.GetMembershipsByStaffIdAsync(memberId);
        return Ok(memberships);
    }

    [HttpPost]
    public async Task<ActionResult<MembershipDto>> Create([FromBody] CreateMembershipDto createDto)
    {
        var membership = await _membershipService.CreateMembershipAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = membership.Id }, membership);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MembershipDto>> Update(int id, [FromBody] UpdateMembershipDto updateDto)
    {
        updateDto.Id = id; // Set the ID from the route
        var membership = await _membershipService.UpdateMembershipAsync(updateDto);
        if (membership == null)
            return NotFound();
        return Ok(membership);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _membershipService.DeleteMembershipAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}