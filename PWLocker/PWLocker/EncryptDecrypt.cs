using System;
using System.Text;
using System.Security.Cryptography;

namespace PWLocker
{
    public class EncryptDecrypt
    {
        private byte[] Key { get; set; }
        private byte[] IV { get; set; }

        public EncryptDecrypt(string keyString, string ivString)
        {
            // Kulcs és IV generálása a megadott stringekből
            using (SHA256 sha256 = SHA256.Create()) // Helyes hivatkozás a SHA256.Create() metódusra
            {
                Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(keyString)).Take(24).ToArray(); // TripleDES 24 byte-os kulcsot használ
                IV = sha256.ComputeHash(Encoding.UTF8.GetBytes(ivString)).Take(8).ToArray(); // IV-nek 8 byte kell
            }
        }

        public string Encrypt(string text)
        {
            var buffer = Encoding.UTF8.GetBytes(text);

            using (var tripleDes = new TripleDESCryptoServiceProvider())
            {
                tripleDes.Key = Key;
                tripleDes.IV = IV;
                tripleDes.Padding = PaddingMode.PKCS7;
                tripleDes.Mode = CipherMode.CBC;

                ICryptoTransform transform = tripleDes.CreateEncryptor();
                var cipherText = transform.TransformFinalBlock(buffer, 0, buffer.Length);
                return Convert.ToBase64String(cipherText);
            }
        }

        public string Decrypt(string encryptedText)
        {
            var buffer = Convert.FromBase64String(encryptedText);

            using (var tripleDes = new TripleDESCryptoServiceProvider())
            {
                tripleDes.Key = Key;
                tripleDes.IV = IV;
                tripleDes.Padding = PaddingMode.PKCS7;
                tripleDes.Mode = CipherMode.CBC;

                ICryptoTransform transform = tripleDes.CreateDecryptor();
                var plainText = transform.TransformFinalBlock(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(plainText);
            }
        }
    }
}
