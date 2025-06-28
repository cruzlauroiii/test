using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Services.UseCases.AssociatedCompanies;

public class AssociatedCompanyService : IAssociatedCompanyService
{
    private readonly IAssociatedCompanyRepository _associatedCompanyRepository;

    public AssociatedCompanyService(IAssociatedCompanyRepository associatedCompanyRepository)
    {
        _associatedCompanyRepository = associatedCompanyRepository;
    }

    public async Task<IEnumerable<AssociatedCompany>> GetAllAssociatedCompaniesAsync()
    {
        return await _associatedCompanyRepository.GetAllAsync();
    }

    public async Task<AssociatedCompany?> GetAssociatedCompanyByIdAsync(int id)
    {
        return await _associatedCompanyRepository.GetByIdAsync(id);
    }

    public async Task<AssociatedCompany?> GetAssociatedCompanyByCodeAsync(string companyCode)
    {
        return await _associatedCompanyRepository.GetByCompanyCodeAsync(companyCode);
    }

    public async Task<AssociatedCompany> CreateAssociatedCompanyAsync(AssociatedCompany associatedCompany)
    {
        return await _associatedCompanyRepository.CreateAsync(associatedCompany);
    }

    public async Task<AssociatedCompany> UpdateAssociatedCompanyAsync(AssociatedCompany associatedCompany)
    {
        return await _associatedCompanyRepository.UpdateAsync(associatedCompany);
    }

    public async Task<bool> DeleteAssociatedCompanyAsync(int id)
    {
        return await _associatedCompanyRepository.DeleteAsync(id);
    }
}