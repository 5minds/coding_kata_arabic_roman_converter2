using ArabicRomanConverter.Absraction;
using ArabicRomanConverter.Implementation;
using System;

namespace ArabicRomanConverter
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("The program accept only 1 argument, arabic or roman numeral!");
                return;
            }
            string argument = args[0];
            int.TryParse(argument, out int result);

            IConverter<string, int> converter = ConverterFactory.Build<string, int>();
            IValidator<string, int> validator = ValidatorFactory.Build<string, int>();

            if (result > 0)
            {
                if (!validator.validateFrom(result))
                {
                    Console.Error.WriteLine($"The number ( {result} ) can't be converted to roman numerals, please provide number in range 0-3999");
                    return;
                }
                Console.WriteLine("The converted roman numeral is " + converter.convertFrom(result));
            }
            else
            {
                if (!validator.validateTo(argument))
                {
                    Console.Error.WriteLine("Can't be convert roman numeral to arabic number, please provide a valid roman numeral");
                    return;
                }
                Console.WriteLine("The converted arabic numeral is " + converter.convertTo(argument));
            }
        }
    }
}
