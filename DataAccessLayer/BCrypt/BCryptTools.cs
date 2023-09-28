using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;

namespace FlyBooking.DAL
{
    public static class BCryptTool
    {
        // Generates a random salt using the BCrypt with a cost factor of 12
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        // Hashes a password using the BCrypt and a random salt
        public static string HashPassword(string password)
        {
            string salt = GetRandomSalt();

            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        // Verifies a password against a previously hashed value
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
