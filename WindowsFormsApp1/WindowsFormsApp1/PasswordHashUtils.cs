using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class PasswordHashUtils
    {
        public static byte[] GenerateSalt(int bytes)
        {
            var saltBytes = new byte[bytes];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return saltBytes;
        }

        public static string GenerateSaltHash(int bytes)
        {
            return Convert.ToBase64String(GenerateSalt(bytes));
        }

        public static string HashPassword128Bit(string password, string salt)
        {
            return HashPassword(password, salt, 69732, 16);
        }

        public static string HashPassword(string password, string salt, int nIterations, int nHash)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }

        public static bool VerifyHashPassword(string password, string passwordHash, string saltHash)
        {
            return HashPassword128Bit(password, saltHash) == passwordHash;
        }
    }
}
