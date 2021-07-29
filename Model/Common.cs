using System;
using System.Security.Cryptography;
using System.Text;

namespace Model
{
    public static class Common
    {
        public static string MD5String(string str)
        {
            MD5 md5Hash = MD5.Create();
            byte[] md5 = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
            string md5String = BitConverter.ToString(md5).ToLower();
            md5String = md5String.Replace("-", "");
            return md5String;
        }
    }
}