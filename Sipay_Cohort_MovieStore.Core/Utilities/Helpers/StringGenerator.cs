using System.Security.Cryptography;

namespace Sipay_Cohort_MovieStore.Core.Utilities.Helpers
{
    public static class StringGenerator
    {
        public static string GenerateRandomPassword(int length = 12)
        {

            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+";
            char[] chars = new char[length];

            using (RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[length];

                cryptoProvider.GetBytes(data);

                for (int i = 0; i < length; i++)
                {
                    chars[i] = validChars[data[i] % validChars.Length];
                }
            }
            return new string(chars);

        }
    }
}
