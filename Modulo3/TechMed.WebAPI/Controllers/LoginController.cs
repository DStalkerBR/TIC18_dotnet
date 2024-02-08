using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService service) => _loginService = service;

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginInputModel login)
    {
        throw new NotImplementedException();        
    }
}
