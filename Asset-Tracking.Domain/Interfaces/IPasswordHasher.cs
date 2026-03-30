using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        public string Hash(string password);
        public bool Verify(string password, string hash);
    }
}


