using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.DTOs;
using Domain.Entities;

namespace BlazorWebApp.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class MembershipsController : ControllerBase
{
    private readonly IMembershipRepository _membershipRepository;

    public MembershipsController(IMembershipRepository membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var memberships = await _membershipRepository.GetAllAsync();
        return Ok(memberships);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var membership = await _membershipRepository.GetByIdAsync(id);
        if (membership == null)
            return NotFound();
        return Ok(membership);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMembershipDto membershipDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var membership = new Membership
        {
            MembershipNo = membershipDto.MembershipNo,
            MemberPassword = membershipDto.MemberPassword,
            MemberId = membershipDto.MemberId,
            MembershipType = membershipDto.MembershipType,
            RemoteStaffId = membershipDto.RemoteStaffId,
            Company = membershipDto.Company,
            PrimaryCompany = membershipDto.PrimaryCompany,
            CompanyGroup = membershipDto.CompanyGroup,
            MainLogoLocation = membershipDto.MainLogoLocation,
            ReportLogoLocation = membershipDto.ReportLogoLocation
        };

        var createdMembership = await _membershipRepository.CreateAsync(membership);
        return CreatedAtAction(nameof(GetById), new { id = createdMembership.Id }, createdMembership);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMembershipDto membershipDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingMembership = await _membershipRepository.GetByIdAsync(id);
        if (existingMembership == null)
            return NotFound();

        existingMembership.MembershipNo = membershipDto.MembershipNo;
        existingMembership.MemberPassword = membershipDto.MemberPassword;
        existingMembership.MemberId = membershipDto.MemberId;
        existingMembership.MembershipType = membershipDto.MembershipType;
        existingMembership.RemoteStaffId = membershipDto.RemoteStaffId;
        existingMembership.Company = membershipDto.Company;
        existingMembership.PrimaryCompany = membershipDto.PrimaryCompany;
        existingMembership.CompanyGroup = membershipDto.CompanyGroup;
        existingMembership.MainLogoLocation = membershipDto.MainLogoLocation;
        existingMembership.ReportLogoLocation = membershipDto.ReportLogoLocation;

        var updatedMembership = await _membershipRepository.UpdateAsync(existingMembership);
        return Ok(updatedMembership);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _membershipRepository.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}