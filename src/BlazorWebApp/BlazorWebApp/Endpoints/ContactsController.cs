using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using BlazorWebApp.Client.DTO.Contact;
using Domain.BusinessObjects;

namespace BlazorWebApp.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _contactRepository;

    public ContactsController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _contactRepository.GetAllAsync();
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _contactRepository.GetByIdAsync(id);
        if (contact == null)
            return NotFound();
        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContact contactDto)
    {
        var contact = new Domain.BusinessObjects.Contact
        {
            Company = contactDto.Company,
            FirstName = contactDto.FirstName,
            SurName = contactDto.LastName, // Map to SurName
            Defaultdoorsfacing = contactDto.Defaultdoorsfacing,
            Ffeligible = contactDto.Ffeligible,
            SguId = contactDto.SguId,
            IclientInvoiceValIdationDay = contactDto.IclientInvoiceValIdationDay
        };
        
        await _contactRepository.CreateAsync(contact);
        return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateContact contactDto)
    {
        if (id != contactDto.Id)
            return BadRequest();
            
        var existingContact = await _contactRepository.GetByIdAsync(id);
        if (existingContact == null)
            return NotFound();

        // Update properties
        existingContact.Company = contactDto.Company;
        existingContact.FirstName = contactDto.FirstName;
        existingContact.SurName = contactDto.LastName; // Map to SurName
        
        await _contactRepository.UpdateAsync(existingContact);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _contactRepository.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}