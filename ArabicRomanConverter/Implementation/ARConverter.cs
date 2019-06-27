using ArabicRomanConverter.Absraction;
using ArabicRomanConverter.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ArabicRomanConverter.Implementation
{

    public class ARConverter : IConverter<string, int>
    {
        private static readonly List<RomanNumber> RomanNumerals = new List<RomanNumber>() {
                RomanNumber.M,
                RomanNumber.CM,
                RomanNumber.D,
                RomanNumber.CD,
                RomanNumber.C,
                RomanNumber.XC,
                RomanNumber.L,
                RomanNumber.XL,
                RomanNumber.X,
                RomanNumber.IX,
                RomanNumber.V,
                RomanNumber.IV,
                RomanNumber.I,
            };

        private IValidator<string, int> validator = ValidatorFactory.Build<string, int>();

        public int convertTo(string roman)
        {
            if (!this.validator.validateTo(roman))
            {
                throw new ArgumentException("Can have only valid roman numerals in the input");
            }
            roman = roman.ToUpperInvariant();
            int result = 0;
            int i = 0;
            while ((roman.Length > 0) && (i < RomanNumerals.Count))
            {
                var symbol = RomanNumerals[i];
                if (roman.StartsWith(symbol.ToString()))
                {
                    result += symbol.IntValue();
                    roman = roman.Substring(symbol.ToString().Length);
                }
                else
                {
                    i++;
                }
            }
            if (roman.Length > 0)
            {
                throw new ArgumentException(roman + " cannot be converted as its not valid Roman numeral");
            }
            return result;
        }

        public string convertFrom(int arabicNumber)
        {
            if (!this.validator.validateFrom(arabicNumber))
            {
                throw new ArgumentException(arabicNumber + " is not in correct range (0,4000]");
            }

            StringBuilder romanNumeralBuilder = new StringBuilder();

            int i = 0;
            while ((arabicNumber > 0) && (i < RomanNumerals.Count))
            {
                var symbol = RomanNumerals[i];
                if (symbol.IntValue() <= arabicNumber)
                {
                    romanNumeralBuilder.Append(symbol.ToString());
                    arabicNumber -= symbol.IntValue();
                }
                else
                {
                    i++;
                }
            }
            return romanNumeralBuilder.ToString();
        }
    }
}
