using Domain.DTOs;

namespace Application.Interfaces;

public interface IAuthApplicationService
{
    Task<string?> LoginAsync(LoginDto dto);
}