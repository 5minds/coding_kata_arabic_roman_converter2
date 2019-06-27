using ArabicRomanConverter.Absraction;
using System.Text.RegularExpressions;

namespace ArabicRomanConverter.Implementation
{
    public class ARValidator : IValidator<string, int>
    {
        private const int MAX_NUMBER_TO_ROMAN = 3999;
        private static readonly Regex checker = new Regex(@"^[MDCLXVI]+$", RegexOptions.IgnoreCase);

        public bool validateFrom(int arabic)
        {
            return 0 < arabic && arabic <= MAX_NUMBER_TO_ROMAN;
        }

        public bool validateTo(string roman)
        {
            return !string.IsNullOrEmpty(roman) && checker.IsMatch(roman);
        }
    }
}
