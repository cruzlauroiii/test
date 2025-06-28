using Application.DTOs;

namespace Application.Interfaces.Services;

public interface IContactService
{
    Task<IEnumerable<ContactDto>> GetAllContactsAsync();
    Task<ContactDto?> GetContactByIdAsync(int id);
    Task<ContactDto> CreateContactAsync(CreateContactDto createContactDto);
    Task<ContactDto> UpdateContactAsync(int id, UpdateContactDto updateContactDto);
    Task<bool> DeleteContactAsync(int id);
}

public interface IAssociatedCompanyService
{
    Task<IEnumerable<AssociatedCompanyDto>> GetAllAssociatedCompaniesAsync();
    Task<AssociatedCompanyDto?> GetAssociatedCompanyByIdAsync(int id);
    Task<AssociatedCompanyDto?> GetAssociatedCompanyByCompanyCodeAsync(string companyCode);
    Task<AssociatedCompanyDto> CreateAssociatedCompanyAsync(CreateAssociatedCompanyDto createAssociatedCompanyDto);
    Task<AssociatedCompanyDto> UpdateAssociatedCompanyAsync(int id, UpdateAssociatedCompanyDto updateAssociatedCompanyDto);
    Task<bool> DeleteAssociatedCompanyAsync(int id);
}

public interface IIPadUserOptionService
{
    Task<IEnumerable<IPadUserOptionDto>> GetAllIPadUserOptionsAsync();
    Task<IPadUserOptionDto?> GetIPadUserOptionByIdAsync(int id);
    Task<IPadUserOptionDto?> GetIPadUserOptionByStaffIdAsync(int staffId);
    Task<IPadUserOptionDto> CreateIPadUserOptionAsync(CreateIPadUserOptionDto createIPadUserOptionDto);
    Task<IPadUserOptionDto> UpdateIPadUserOptionAsync(int id, UpdateIPadUserOptionDto updateIPadUserOptionDto);
    Task<bool> DeleteIPadUserOptionAsync(int id);
}

public interface IDeliveryPreStartService
{
    Task<IEnumerable<DeliveryPreStartDto>> GetAllDeliveryPreStartsAsync();
    Task<DeliveryPreStartDto?> GetDeliveryPreStartByIdAsync(int id);
    Task<DeliveryPreStartDto?> GetDeliveryPreStartByPreStartIdAsync(int preStartId);
    Task<DeliveryPreStartDto> CreateDeliveryPreStartAsync(CreateDeliveryPreStartDto createDeliveryPreStartDto);
    Task<DeliveryPreStartDto> UpdateDeliveryPreStartAsync(int id, UpdateDeliveryPreStartDto updateDeliveryPreStartDto);
    Task<bool> DeleteDeliveryPreStartAsync(int id);
}