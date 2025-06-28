using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Contacts;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<IEnumerable<ContactDto>> GetAllContactsAsync()
    {
        var contacts = await _contactRepository.GetAllAsync();
        return contacts.Select(MapToDto);
    }

    public async Task<ContactDto?> GetContactByIdAsync(int id)
    {
        var contact = await _contactRepository.GetByIdAsync(id);
        return contact != null ? MapToDto(contact) : null;
    }

    public async Task<ContactDto> CreateContactAsync(CreateContactDto dto)
    {
        var contact = new Contact
        {
            AssignedCompany = dto.AssignedCompany,
            Company = dto.Company,
            CompanyGroup = dto.CompanyGroup
        };

        var createdContact = await _contactRepository.CreateAsync(contact);
        return MapToDto(createdContact);
    }

    public async Task<ContactDto> UpdateContactAsync(UpdateContactDto dto)
    {
        var contact = await _contactRepository.GetByIdAsync(dto.Id);
        if (contact == null)
            throw new ArgumentException("Contact not found");

        contact.AssignedCompany = dto.AssignedCompany;
        contact.Company = dto.Company;
        contact.CompanyGroup = dto.CompanyGroup;

        var updatedContact = await _contactRepository.UpdateAsync(contact);
        return MapToDto(updatedContact);
    }

    public async Task<bool> DeleteContactAsync(int id)
    {
        return await _contactRepository.DeleteAsync(id);
    }

    private static ContactDto MapToDto(Contact contact)
    {
        return new ContactDto
        {
            Id = contact.Id,
            AssignedCompany = contact.AssignedCompany,
            Company = contact.Company,
            CompanyGroup = contact.CompanyGroup
        };
    }
}