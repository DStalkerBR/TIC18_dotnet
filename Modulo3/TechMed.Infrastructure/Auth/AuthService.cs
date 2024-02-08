using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace TechMed.Infrastructure.Auth;
public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    public AuthService(IConfiguration configuration) => _configuration = configuration;
    public string ComputeSha256Hash (string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create()){
            var hashedBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }
    }

    public string GenerateToken(string username, string role){
        throw new NotImplementedException(); 
    }

}
