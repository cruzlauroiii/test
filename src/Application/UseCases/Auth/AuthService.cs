using Application.DTOs;
using Domain.Interfaces;

namespace Application.UseCases.Auth;

public class AuthService
{
    private readonly IStaffRepository _staffRepository;
    private readonly IAuthService _authService;

    public AuthService(IStaffRepository staffRepository, IAuthService authService)
    {
        _staffRepository = staffRepository;
        _authService = authService;
    }

    public async Task<string?> LoginAsync(LoginDto dto)
    {
        var staff = await _staffRepository.GetByUsernameAsync(dto.Username);
        if (staff == null || !staff.IsActive)
            return null;

        if (!await _authService.VerifyPasswordAsync(dto.Password, staff.PasswordHash))
            return null;

        staff.LastLoginAt = DateTime.UtcNow;
        await _staffRepository.UpdateAsync(staff);

        return await _authService.GenerateTokenAsync(staff);
    }
}