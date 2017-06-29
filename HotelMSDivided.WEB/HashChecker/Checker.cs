using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HotelMSDivided.WEB.HashChecker
{
    public class Checker
    {
        private const string checkHash = "c3bcf54a5b844d03700bc3440255d74a";
        private string input;
        private MD5 md5Hasher;

        public Checker(string input)
        {
            this.input = input;
            md5Hasher = MD5.Create();
        }

        private string GetMd5Hash()
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool VerifyMd5Hash()
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash();

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return (0 == comparer.Compare(hashOfInput, checkHash));
        }
    }
}