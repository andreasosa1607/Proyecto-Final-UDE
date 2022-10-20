using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AV.BL
{
    public static class  Encriptar
    {

        public static string MD5(string contraseña) 
        {



            //byte[] salt = new byte[128 / 8];
            string salt = "test";
            //using (var rngCsp = new RNGCryptoServiceProvider())
            //{
            //    rngCsp.GetNonZeroBytes(salt);
            //}


            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: contraseña,
                salt: Encoding.ASCII.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
            
        }
    }
}

