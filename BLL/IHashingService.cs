using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.BLL
{
    interface IHashingService
    {
        public string GenerateSalt();
        public string GenerateHash(string salt, string password);
        public bool CheckIfHashMatches(string dbHash, string newHash);
    }
}
