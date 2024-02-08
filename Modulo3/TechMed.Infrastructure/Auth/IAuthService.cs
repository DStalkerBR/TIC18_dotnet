namespace TechMed.Infrastructure.Auth;
public interface IAuthService   
{
    string GenerateToken(string username, string role);
    string ComputeSha256Hash(string rawData);
}
