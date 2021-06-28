using Application.Helpers;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Helpers
{
    public class EfHashPasswordService : IHashPassword
    {
        public string Encrypt(string password)
        {
            var salt = "FbSnXHPo12gb";
            byte[] saltBytes = Convert.FromBase64String(salt);
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
            return hashedPassword;
        }
    }
}
