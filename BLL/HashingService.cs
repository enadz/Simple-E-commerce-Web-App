using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace apshop.BLL
{
    public class HashingService:IHashingService
    {
        public string GenerateSalt()
        {
            var buf = new byte[8];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);

        }

        public string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm alghoritm = HashAlgorithm.Create("SHA1");
            byte[] inArray = alghoritm.ComputeHash(dst);

            return Convert.ToBase64String(inArray);
        }

        public bool CheckIfHashMatches(string dbHash, string newHash)
        {
            if (dbHash != newHash) return false;
           
            else return true;
        }
    }
}
