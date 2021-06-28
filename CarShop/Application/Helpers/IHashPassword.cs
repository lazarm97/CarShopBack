using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
    public interface IHashPassword
    {
        string Encrypt(string password);
    }
}
