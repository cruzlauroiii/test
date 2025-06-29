using Domain.BusinessObjects;

namespace Application.Interfaces;

public interface IAssociatedCompanyService
{
    Task<IEnumerable<AssociatedCompany>> GetAllAssociatedCompaniesAsync();
    Task<AssociatedCompany?> GetAssociatedCompanyByIdAsync(int id);
    Task<AssociatedCompany?> GetAssociatedCompanyByCodeAsync(string companyCode);
    Task<AssociatedCompany> CreateAssociatedCompanyAsync(AssociatedCompany associatedCompany);
    Task<AssociatedCompany> UpdateAssociatedCompanyAsync(AssociatedCompany associatedCompany);
    Task<bool> DeleteAssociatedCompanyAsync(int id);
}