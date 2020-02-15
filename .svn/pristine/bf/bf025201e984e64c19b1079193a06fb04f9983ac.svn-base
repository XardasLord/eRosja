using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eRosja
{
    public static class Hash
    {
        // Funkcja hashująca hasło w SHA1
        public static string ZakodujSHA1(string haslo)
        {
            SHA1Managed s = new SHA1Managed();
            UTF8Encoding enc = new UTF8Encoding();
            s.ComputeHash(enc.GetBytes(haslo.ToCharArray()));
            System.Diagnostics.Debug.WriteLine("Original Text {0}, Access {1}", haslo, Convert.ToBase64String(s.Hash));
            return BitConverter.ToString(s.Hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
