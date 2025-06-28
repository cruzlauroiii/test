using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Contacts;

public class ContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _contactRepository.GetAllAsync();
    }

    public async Task<Contact?> GetContactByIdAsync(int id)
    {
        return await _contactRepository.GetByIdAsync(id);
    }

    public async Task<Contact> CreateContactAsync(Contact contact)
    {
        return await _contactRepository.CreateAsync(contact);
    }

    public async Task<Contact> UpdateContactAsync(Contact contact)
    {
        return await _contactRepository.UpdateAsync(contact);
    }

    public async Task<bool> DeleteContactAsync(int id)
    {
        return await _contactRepository.DeleteAsync(id);
    }
}