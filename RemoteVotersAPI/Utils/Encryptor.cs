using System.Security.Cryptography;
using System.Text;

namespace remotevotersapi.Utils
{
    /// <summary>
    /// Class responsible for encrypting data 
    /// </summary>
    public static class Encryptor
    {
        /// <summary>
        /// Returns an encrypted string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>encrypted string</returns>
        public static string Encrypt(string input)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(input))
            {
                MD5 md5 = MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }
    }
}
