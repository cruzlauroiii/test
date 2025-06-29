using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using BlazorWebApp.Client.DTO.AssociatedCompany;
using Domain.BusinessObjects;

namespace BlazorWebApp.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class AssociatedCompaniesController : ControllerBase
{
    private readonly IAssociatedCompanyRepository _associatedCompanyRepository;

    public AssociatedCompaniesController(IAssociatedCompanyRepository associatedCompanyRepository)
    {
        _associatedCompanyRepository = associatedCompanyRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await _associatedCompanyRepository.GetAllAsync();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var company = await _associatedCompanyRepository.GetByIdAsync(id);
        if (company == null)
            return NotFound();
        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAssociatedCompanyDto companyDto)
    {
        var company = new AssociatedCompany
        {
            IdAssociatedCompany = companyDto.IdAssociatedCompany,
            Bactive = companyDto.Bactive,
            ScompanyName = companyDto.ScompanyName,
            ScompanyCode = companyDto.ScompanyCode,
            SmainLogoLocation = companyDto.SmainLogoLocation,
            SreportLogoLocation = companyDto.SreportLogoLocation,
            SprimaryCompany = companyDto.SprimaryCompany
        };
        
        await _associatedCompanyRepository.CreateAsync(company);
        return CreatedAtAction(nameof(GetById), new { id = company.IdAssociatedCompany }, company);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAssociatedCompanyDto companyDto)
    {
        if (id != companyDto.IdAssociatedCompany)
            return BadRequest();
            
        var existingCompany = await _associatedCompanyRepository.GetByIdAsync(id);
        if (existingCompany == null)
            return NotFound();

        // Update properties
        existingCompany.Bactive = companyDto.Bactive;
        existingCompany.ScompanyName = companyDto.ScompanyName;
        existingCompany.ScompanyCode = companyDto.ScompanyCode;
        existingCompany.SmainLogoLocation = companyDto.SmainLogoLocation;
        existingCompany.SreportLogoLocation = companyDto.SreportLogoLocation;
        existingCompany.SprimaryCompany = companyDto.SprimaryCompany;
        
        await _associatedCompanyRepository.UpdateAsync(existingCompany);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _associatedCompanyRepository.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}