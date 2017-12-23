using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ChromaFramework.Encryption
{
    public static class Rijndael
    {
        public static string Decrypt(string text, string key = "%DEFAULT%", string iv = "%DEFAULT%")
        {
            if (key == "%DEFAULT%")
                key = ChromaEmu.Properties.Settings.Default.key;

            if (iv == "%DEFAULT%")
                iv = ChromaEmu.Properties.Settings.Default.iv;



            string str = key;
            string str1 = iv;
            RijndaelManaged rijndaelManaged = new RijndaelManaged()
            {
                BlockSize = 256,
                KeySize = 256,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.Zeros
            };

            byte[] bytes;
            if (key.Length == 32)
                bytes = Encoding.UTF8.GetBytes(str);
            else
                bytes = Convert.FromBase64String("H8vixq8IKlKdem39KWY9+Uu92/PeI8nbpwtwd95iOzI=");

            byte[] numArray;
            if (key.Length == 32)
                numArray = Encoding.UTF8.GetBytes(str1);
            else
                numArray = Convert.FromBase64String("To1w3uRk0heLJFsCGSnNSgJneVIGR5+CIiUM7PhzFsI=");

            ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(bytes, numArray);
            byte[] numArray1 = Convert.FromBase64String(text);
            byte[] numArray2 = new byte[(int)numArray1.Length];
            MemoryStream memoryStream = new MemoryStream(numArray1);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
            cryptoStream.Read(numArray2, 0, (int)numArray2.Length);
            cryptoStream.Dispose();
            memoryStream.Dispose();
            rijndaelManaged.Dispose();
            return Encoding.UTF8.GetString(numArray2).Replace("\\0", "").Replace("\0", "");
        }

        public static string Encrypt(string text, string key = "%DEFAULT%", string iv = "%DEFAULT%")
        {
            if (key == "%DEFAULT%")
                key = ChromaEmu.Properties.Settings.Default.key;

            if (iv == "%DEFAULT%")
                iv = ChromaEmu.Properties.Settings.Default.iv;

            string str = key;
            string str1 = iv;
            RijndaelManaged rijndaelManaged = new RijndaelManaged()
            {
                BlockSize = 256,
                KeySize = 256,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.Zeros
            };

            byte[] bytes;
            if (key.Length == 32)
                bytes = Encoding.UTF8.GetBytes(str);
            else
                bytes = Convert.FromBase64String(str);

            byte[] numArray;
            if (key.Length == 32)
                numArray = Encoding.UTF8.GetBytes(str1);
            else
                numArray = Convert.FromBase64String(str1);

            ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(bytes, numArray);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
            byte[] bytes1 = Encoding.UTF8.GetBytes(text);
            cryptoStream.Write(bytes1, 0, (int)bytes1.Length);
            cryptoStream.FlushFinalBlock();
            byte[] array = memoryStream.ToArray();
            cryptoStream.Dispose();
            memoryStream.Dispose();
            rijndaelManaged.Dispose();
            return Convert.ToBase64String(array);
        }
    }
}