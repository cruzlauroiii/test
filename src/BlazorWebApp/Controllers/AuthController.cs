using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.UseCases.Auth;

namespace BlazorWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly Application.UseCases.Auth.AuthService _authService;

    public AuthController(Application.UseCases.Auth.AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginDto dto)
    {
        try
        {
            var response = await _authService.LoginAsync(dto);
            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("logout")]
    public ActionResult Logout()
    {
        // For JWT tokens, logout is typically handled client-side
        // by removing the token from storage
        return Ok();
    }
}