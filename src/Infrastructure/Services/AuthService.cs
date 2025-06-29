using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Domain.BusinessObjects;
using Domain.Interfaces;

namespace Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly string _jwtSecret;
    private readonly string _jwtIssuer;

    public AuthService(string jwtSecret = "your-super-secret-key-here", string jwtIssuer = "StaffManagement")
    {
        _jwtSecret = jwtSecret;
        _jwtIssuer = jwtIssuer;
    }

    public async Task<bool> AuthenticateAsync(string username, string password)
    {
        // This will be implemented in conjunction with StaffRepository
        await Task.CompletedTask;
        return false;
    }

    public async Task<string> HashPasswordAsync(string password)
    {
        await Task.CompletedTask;
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public async Task<bool> VerifyPasswordAsync(string password, string hash)
    {
        await Task.CompletedTask;
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }

    public async Task<string> GenerateTokenAsync(Staff staff)
    {
        await Task.CompletedTask;
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, staff.Id.ToString()),
            new(ClaimTypes.Name, staff.Username),
            new(ClaimTypes.Email, staff.Email)
        };

        // Add role claims
        foreach (var staffRole in staff.StaffRoles.Where(sr => sr.IsActive))
        {
            claims.Add(new Claim(ClaimTypes.Role, staffRole.Role.Name));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = _jwtIssuer,
            Audience = _jwtIssuer,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}