using System.Security.Cryptography;
using System.Text;

namespace JWT.Infrastructure.Helpers
{
    public class PasswordHelper
    {
        public static string Hash(string password)
        {
            var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            var result = new StringBuilder();

            foreach (var i in hash)
            {
                result.Append(i.ToString("X2"));
            }

            return result.ToString();
        }

        public static bool Verify(string password, string hashedPassword)
        {
            password = Hash(password);

            return Equals(password, hashedPassword);
        }
    }
}
