using ArabicRomanConverter.Absraction;

namespace ArabicRomanConverter.Helper
{
    public static class Extensions
    {
        public static int IntValue(this RomanNumber romanNumber)
        {
            return (int) romanNumber;
        }
    }
}
