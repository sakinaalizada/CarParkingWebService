using System.Text;

namespace Core.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePassHash
            (string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
