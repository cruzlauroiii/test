using Application.DTOs;

namespace Application.Interfaces;

public interface IContactService
{
    Task<IEnumerable<ContactDto>> GetAllContactsAsync();
    Task<ContactDto?> GetContactByIdAsync(int id);
    Task<ContactDto> CreateContactAsync(CreateContactDto dto);
    Task<ContactDto> UpdateContactAsync(UpdateContactDto dto);
    Task<bool> DeleteContactAsync(int id);
}