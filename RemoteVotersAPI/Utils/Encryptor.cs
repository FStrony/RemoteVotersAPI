using System.Security.Cryptography;
using System.Text;

namespace RemoteVotersAPI.Utils
{
    /// <summary>
    /// Class responsible for encrypting data 
    /// </summary>
    public static class Encryptor
    {
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
