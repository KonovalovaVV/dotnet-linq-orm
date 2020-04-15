using System;

namespace Infrastructure
{
    public class ColorHelper
    {
        public const int DefaultColor = 2309453;
        public static int GetColor(string hexColor)
        {
            return Convert.ToInt32(hexColor, 16);
        }
    }
}
