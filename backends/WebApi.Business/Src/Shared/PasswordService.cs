using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;

namespace WebApi.Business.Src.Shared
{
    public class PasswordService
    {
        public static void HashPassword(string originalPassword, out string hashedPassword, out byte[] salt)
        {
            var hmac = new HMACSHA256(); 
            salt = hmac.Key;
            hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(originalPassword)).ToString();
        }

         public static bool VerifyPassword(string originalPassword, string hashedPassword, byte[] salt)
        {
            var hmac = new HMACSHA256(salt); // created with an assigned key
            var hashedOriginal = hmac.ComputeHash(Encoding.UTF8.GetBytes(originalPassword)).ToString();
            return hashedOriginal == hashedPassword;
        }
    }
}