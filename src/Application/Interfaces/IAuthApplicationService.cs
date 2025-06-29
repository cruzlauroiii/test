using BlazorWebApp.Client.DTO.Staff;

namespace Application.Interfaces;

public interface IAuthApplicationService
{
    Task<string?> LoginAsync(Login dto);
}