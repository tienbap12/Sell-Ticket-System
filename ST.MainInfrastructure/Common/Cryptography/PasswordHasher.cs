using ST.Application.Commons.Abstractions;
using ST.Domain.Commons;
using ST.Domain.Entities;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ST.MainInfrastructure.Common.Cryptography
{
    internal sealed class PasswordHasher : IPasswordHasher, IPasswordHashChecker
    {
        public (string, string) HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.", nameof(password));
            }
            try
            {
                byte[] saltBytes = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(saltBytes);
                }
                var salt = Convert.ToBase64String(saltBytes);

                var hash = GenerateSaltedHash(password, salt);

                return (hash, salt);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public bool HashesMatch(string password, Account user)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }

            var computedHash = GenerateSaltedHash(password, user.Salt);

            return string.Equals(user.Password, computedHash);
        }

        private static string GenerateSaltedHash(string plainText, string salt)
        {
            HashAlgorithm algorithm = SHA512.Create();

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            var plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainTextBytes[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = saltBytes[i];
            }

            return Convert.ToBase64String(algorithm.ComputeHash(plainTextWithSaltBytes));
        }
    }
}
