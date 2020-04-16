namespace Infrastructure
{
    public class ColorHelper
    {
        public const int DefaultColor = 2309453;
        public const string DefaultColorString = "233D4D";

        public static int GetColor(string hexColor = DefaultColorString)
        {
            return int.Parse(hexColor, System.Globalization.NumberStyles.HexNumber);
        }

        public static string GetColor(int color)
        {
            return color.ToString("X");
        }
    }
}
