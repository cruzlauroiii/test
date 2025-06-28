using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.DTOs;

namespace BlazorWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactDto>>> GetAll()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactDto>> GetById(int id)
    {
        var contact = await _contactService.GetContactByIdAsync(id);
        if (contact == null)
            return NotFound();
        return Ok(contact);
    }

    [HttpPost]
    public async Task<ActionResult<ContactDto>> Create([FromBody] CreateContactDto createDto)
    {
        var contact = await _contactService.CreateContactAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ContactDto>> Update(int id, [FromBody] UpdateContactDto updateDto)
    {
        updateDto.Id = id; // Set the ID from the route
        var contact = await _contactService.UpdateContactAsync(updateDto);
        if (contact == null)
            return NotFound();
        return Ok(contact);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _contactService.DeleteContactAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}