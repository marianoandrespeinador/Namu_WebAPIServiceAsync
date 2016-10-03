using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Namu.Entity.ServicePOCOs;

namespace Namu.Entity
{
    public static class Utility
    {
        #region Security

        // Seguridad de encriptamiento basado en el 3DES (Triple Data Encryption Standard) - algoritmo que utiliza 3 llaves de 64-bit

        //-----------Clave aleatoria para encriptamiento
        private const string EncryptKey = "ClaveAleatoria...3*&%45*#9826356*&%&$";

        /// <summary>
        /// Obtiene el Hash basado en la clave aleatoria
        /// </summary>
        private static byte[] ComputedKeyHash
        {
            get
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(EncryptKey));
                hashmd5.Clear();

                return keyArray;
            }
        }

        private static TripleDESCryptoServiceProvider GetCryptoProvider()
        {
            return new TripleDESCryptoServiceProvider
            {
                Key = ComputedKeyHash,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
        }

        /// <summary>
        /// Encripta una cadena basado en el 3DES
        /// </summary>
        public static string Encrypt(string ToEncrypt)
        {
            var toEncryptArray = Encoding.UTF8.GetBytes(ToEncrypt);

            var tDes = GetCryptoProvider();

            var cTransform = tDes.CreateEncryptor();

            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tDes.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        
        /// <summary>
        /// Des-encripta una cadena basado en el 3DES utilizado en esta misma clase
        /// </summary>
        public static string Decrypt(string cypherString)
        {
            var encryptedString = string.Empty;

            var toDecryptArray = Convert.FromBase64String(cypherString);

            var tDes = GetCryptoProvider();

            var cTransform = tDes.CreateDecryptor();

            try
            {
                var resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

                tDes.Clear();
                encryptedString = Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Namu.Entity.Utility");
            }

            return encryptedString;
        }

        #endregion Security

    }
}
