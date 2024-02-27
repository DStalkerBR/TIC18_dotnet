using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.Extensions.Configuration;

namespace MvcMovie.Controllers;
public class LoginController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly MvcMovieContext _context;

    public LoginController(MvcMovieContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Logout()
    {
        Response.Cookies.Delete("Authentication");
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Email,Password")] User user)
    {
        if (ModelState.IsValid)
        {
            string passwordHashed = UsersController.computeSha256Hash(user.Password);
            var userDb = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == passwordHashed);
            if (userDb != null) 
            {
                var token = GenerateJwtToken(userDb.Email, "Admin");

                Response.Cookies.Append("Authentication", token);

                return RedirectToAction("Index", "Movies");
            }
            else
            {
                ModelState.AddModelError("Password", "Essa senha já está em uso pelo usuário Jorge.");
            }
        }
        return RedirectToAction("Index");
    }


    
    public string GenerateJwtToken(string username, string role){
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"] ?? "";
        //cria uma chave utilizando criptografia simétrica
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //cria as credenciais do token
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim("userName", username),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken( //cria o token
            issuer: issuer, //emissor do token
            audience: audience, //destinatário do token
            claims: claims, //informações do usuário
            expires: DateTime.Now.AddMinutes(30), //tempo de expiração do token
            signingCredentials: credentials); //credenciais do token
        

        var tokenHandler = new JwtSecurityTokenHandler(); //cria um manipulador de token

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }

}
