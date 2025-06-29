using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using BlazorWebApp.Client.DTO.IPadUserOption;
using Domain.BusinessObjects;

namespace BlazorWebApp.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class IPadUserOptionsController : ControllerBase
{
    private readonly IIPadUserOptionRepository _iPadUserOptionRepository;

    public IPadUserOptionsController(IIPadUserOptionRepository iPadUserOptionRepository)
    {
        _iPadUserOptionRepository = iPadUserOptionRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var options = await _iPadUserOptionRepository.GetAllAsync();
        return Ok(options);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var option = await _iPadUserOptionRepository.GetByIdAsync(id);
        if (option == null)
            return NotFound();
        return Ok(option);
    }

    [HttpGet("bystaff/{staffId}")]
    public async Task<IActionResult> GetByStaffId(int staffId)
    {
        var option = await _iPadUserOptionRepository.GetByStaffIdAsync(staffId);
        if (option == null)
            return NotFound();
        return Ok(option);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateIPadUserOption optionDto)
    {
        var option = new Domain.BusinessObjects.IPadUserOption
        {
            IdiPadUserOption = optionDto.IdiPadUserOption,
            IstaffId = optionDto.IstaffId,
            BshowCompletedJob = optionDto.BshowCompletedJob,
            BshowDayShiftJob = optionDto.BshowDayShiftJob,
            BshowNightShiftJob = optionDto.BshowNightShiftJob,
            IcurrentPreStartId = optionDto.IcurrentPreStartId
        };
        
        await _iPadUserOptionRepository.CreateAsync(option);
        return CreatedAtAction(nameof(GetById), new { id = option.IdiPadUserOption }, option);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateIPadUserOption optionDto)
    {
        if (id != optionDto.IdiPadUserOption)
            return BadRequest();
            
        var existingOption = await _iPadUserOptionRepository.GetByIdAsync(id);
        if (existingOption == null)
            return NotFound();

        // Update properties
        existingOption.BshowCompletedJob = optionDto.BshowCompletedJob;
        existingOption.BshowDayShiftJob = optionDto.BshowDayShiftJob;
        existingOption.BshowNightShiftJob = optionDto.BshowNightShiftJob;
        existingOption.IstaffId = optionDto.IstaffId;
        existingOption.IcurrentPreStartId = optionDto.IcurrentPreStartId;
        
        await _iPadUserOptionRepository.UpdateAsync(existingOption);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _iPadUserOptionRepository.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}