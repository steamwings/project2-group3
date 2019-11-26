using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace PizzaMvcUI.Utilities
{
    public static class HashHelper
    {
        public static string HashWithExistingSalt(string pass, string salt)
        {
            using var hasher = new SHA256Managed();

            // convert to bytes
            var passBytes = Encoding.UTF8.GetBytes(pass);
            var saltBytes = Convert.FromBase64String(salt);

            byte[] combinedBytes = new byte[passBytes.Length + saltBytes.Length];
            for (int i = 0; i < passBytes.Length; i++)
            {
                combinedBytes[i] = passBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                combinedBytes[passBytes.Length + i] = saltBytes[i];
            }

            return Convert.ToBase64String(hasher.ComputeHash(combinedBytes));
        }

        public static string HashWithNewSalt(string pass, out string salt)
        {
            using var hasher = new SHA256Managed();
            var random = new Random();

            // convert to bytes
            var passBytes = Encoding.UTF8.GetBytes(pass);

            // generate salt bytes & convert to string for out variable
            var saltBytes = new byte[16];
            random.NextBytes(saltBytes);
            salt = Convert.ToBase64String(saltBytes);

            byte[] combinedBytes = new byte[passBytes.Length + saltBytes.Length];
            for (int i = 0; i < passBytes.Length; i++)
            {
                combinedBytes[i] = passBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                combinedBytes[passBytes.Length + i] = saltBytes[i];
            }

            return Convert.ToBase64String(hasher.ComputeHash(combinedBytes));
        }
    }
}
