using System.Security.Cryptography;
using System.Text;

namespace IToolKit.API.Tools.Hashings
{
    public class HashingsTool
    {
        public static string ComputeSHA1Hash(string input)
        {
            using var sha = SHA1.Create();
            return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }

        public static string ComputeSHA256Hash(string input)
        {
            using var sha = SHA256.Create();
            return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }

        public static string ComputeSHA384Hash(string input)
        {
            using var sha = SHA384.Create();
            return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }

        public static string ComputeSHA512Hash(string input)
        {
            using var sha = SHA512.Create();
            return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
    }
}
