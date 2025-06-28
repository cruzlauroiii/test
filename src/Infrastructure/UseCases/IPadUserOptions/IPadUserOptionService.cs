using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.UseCases.IPadUserOptions;

public class IPadUserOptionService : IIPadUserOptionService
{
    private readonly IIPadUserOptionRepository _iPadUserOptionRepository;

    public IPadUserOptionService(IIPadUserOptionRepository iPadUserOptionRepository)
    {
        _iPadUserOptionRepository = iPadUserOptionRepository;
    }

    public async Task<IEnumerable<IPadUserOption>> GetAllIPadUserOptionsAsync()
    {
        return await _iPadUserOptionRepository.GetAllAsync();
    }

    public async Task<IPadUserOption?> GetIPadUserOptionByIdAsync(int id)
    {
        return await _iPadUserOptionRepository.GetByIdAsync(id);
    }

    public async Task<IPadUserOption?> GetIPadUserOptionByStaffIdAsync(int staffId)
    {
        return await _iPadUserOptionRepository.GetByStaffIdAsync(staffId);
    }

    public async Task<IPadUserOption> CreateIPadUserOptionAsync(IPadUserOption iPadUserOption)
    {
        return await _iPadUserOptionRepository.CreateAsync(iPadUserOption);
    }

    public async Task<IPadUserOption> UpdateIPadUserOptionAsync(IPadUserOption iPadUserOption)
    {
        return await _iPadUserOptionRepository.UpdateAsync(iPadUserOption);
    }

    public async Task<bool> DeleteIPadUserOptionAsync(int id)
    {
        return await _iPadUserOptionRepository.DeleteAsync(id);
    }
}