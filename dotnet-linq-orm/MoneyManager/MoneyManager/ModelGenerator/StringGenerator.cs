using System;
using System.Linq;

namespace DataAccess.ModelGenerator
{
    public static class StringGenerator
    {
        private const int DefaultLength = 7;

        public static string RandomString(int length = DefaultLength)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var sequence = Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray();

            return new string(sequence);
        }
    }
}
