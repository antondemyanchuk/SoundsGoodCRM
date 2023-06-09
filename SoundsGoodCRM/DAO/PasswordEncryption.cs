﻿using System.Security.Cryptography;
using System.Text;

namespace SoundsGoodCRM.DAO
{
    public class PasswordEncryption
    {
        // hash password
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashedBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
