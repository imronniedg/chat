using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Services
{
    public class CipherService
    {
        private string _key {get;set;}

        private byte[] IV =
                        {
                            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                        };

        public CipherService(string key)
        {
            _key = key;
        }

        private byte[] GetKey()
        {
            var emptySalt = Array.Empty<byte>();
            int iterations = 1000;
            int length = 16;
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(_key),
                                             emptySalt,
                                             iterations,
                                             hashMethod,
                                             length);
        }

        public async Task<byte[]> EncryptAsync(string clearText)
        {
            using Aes aes = Aes.Create();
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = GetKey();
            aes.IV = IV;
            using MemoryStream output = new();
            using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);
            await cryptoStream.WriteAsync(Encoding.UTF8.GetBytes(clearText));
            await cryptoStream.FlushFinalBlockAsync();
            return output.ToArray();
        }

        public async Task<string> DecryptAsync(byte[] encrypted)
        {
            try
            {

            using Aes aes = Aes.Create();
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = GetKey();
            aes.IV = IV;
            using MemoryStream input = new(encrypted);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);
            return Encoding.UTF8.GetString(output.ToArray());
            }catch (Exception ex)
            {
                return null;
            }
        }

    }
}
