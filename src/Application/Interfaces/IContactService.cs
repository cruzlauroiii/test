using BlazorWebApp.Client.DTO.Contact;

namespace Application.Interfaces;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllContactsAsync();
    Task<Contact?> GetContactByIdAsync(int id);
    Task<Contact> CreateContactAsync(CreateContact dto);
    Task<Contact> UpdateContactAsync(UpdateContact dto);
    Task<bool> DeleteContactAsync(int id);
}