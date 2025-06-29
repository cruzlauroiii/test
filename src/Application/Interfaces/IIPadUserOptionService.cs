using Domain.BusinessObjects;

namespace Application.Interfaces;

public interface IIPadUserOptionService
{
    Task<IEnumerable<IPadUserOption>> GetAllIPadUserOptionsAsync();
    Task<IPadUserOption?> GetIPadUserOptionByIdAsync(int id);
    Task<IPadUserOption?> GetIPadUserOptionByStaffIdAsync(int staffId);
    Task<IPadUserOption> CreateIPadUserOptionAsync(IPadUserOption iPadUserOption);
    Task<IPadUserOption> UpdateIPadUserOptionAsync(IPadUserOption iPadUserOption);
    Task<bool> DeleteIPadUserOptionAsync(int id);
}