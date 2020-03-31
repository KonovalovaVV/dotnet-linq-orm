using System;
using System.Linq;

namespace MoneyManager.ModelGenerator
{
    public static class StringGenerator
    {
        private const int fieldLength = 7;

        public static string RandomString()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, fieldLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
