using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SHS.Infrastructu.Encrypt
{
    public class MD5Encrypt
    {
        /// <summary>
        /// MD516位加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EncryptBy16(string input)
        {
            string result = string.Empty;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string output = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input)), 4, 8);
            result = output.Replace("-", "");
            return result;
        }
        /// <summary>
        /// MD532位加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EncryptBy32(string input)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                MD5 md5 = MD5.Create();
                byte[] output = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                for (int i = 0; i < output.Length; i++)
                {
                    result += output[i].ToString("x");
                }
            }

            return result;
        }
    }
}
