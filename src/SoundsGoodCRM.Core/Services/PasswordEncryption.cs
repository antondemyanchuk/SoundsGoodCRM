using System.Text;
using System.Security.Cryptography;

namespace SoundsGoodCRM.Core.Services
{
    public static class PasswordEncryption
    {
        public static string HashPassword(this string password)
        {
            using var sha256 = SHA256.Create();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
