using System;
using System.Text;
using System.Security.Cryptography;

namespace Base.Core.Util
{
    public class Cryptography : ICryptography
    {
        private string key = "RicardoLuiz@1965";

        public string Decrypt(string text)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            des.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = des.CreateDecryptor();
            text = text.Replace(" ", "+");
            int mod4 = text.Length % 4;
            if (mod4 > 0)
            {
                text += new string('=', 4 - mod4);
            }
            byte[] buff = Convert.FromBase64String(text);

            return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        }

        public string Encrypt(string text)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            des.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = des.CreateEncryptor();
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(text);

            return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        }
    }
}
