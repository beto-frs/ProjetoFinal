using System.Security.Cryptography;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace Destino_Certo.Crypto
{
    public class Crypto: ICrypto
    {
        

        public string Encrypt(string password)
        {
            if (password == null) throw new ArgumentNullException("plainText");

            //encrypt data
            var data = Encoding.Unicode.GetBytes(password);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string password)
        {
            if (password == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(password);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}
