using System.Security.Cryptography;
using System.Text;

namespace PayCredApp.Configuraciones
{
    public class Seguridad
    {
        private readonly static string Hash = "2017-0518";
        public static string Encrypt(string Password)
        {
            byte[] data = Encoding.UTF32.GetBytes(Password);

            MD5 md5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();

            tripleDES.Key = md5.ComputeHash(Encoding.UTF32.GetBytes(Hash));
            tripleDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDES.CreateEncryptor();

            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);
        }

        public static string Descrypt(string PasswordEncrypt)
        {
            byte[] data = Convert.FromBase64String(PasswordEncrypt);

            MD5 md5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();

            tripleDES.Key = md5.ComputeHash(Encoding.UTF32.GetBytes(Hash));
            tripleDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDES.CreateDecryptor();

            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Encoding.UTF32.GetString(result);
        }
    }
}
