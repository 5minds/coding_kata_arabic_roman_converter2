using ArabicRomanConverter.Implementation;
using FluentAssertions;
using System;
using Xunit;

namespace ArabicRomanConverter.Tests
{
    public class ArabicRomanConverterTest
    {
        [Theory]
        [InlineData("MMXIX", 2019)]
        [InlineData("MCMXCIV", 1994)]
        [InlineData("MCMXLIX", 1949)]
        [InlineData("MCDXCIV", 1494)]
        [InlineData("mCdXcIV", 1494)]
        [InlineData("mcmxlix", 1949)]
        [InlineData("D", 500)]
        [InlineData("I", 1)]
        public void TestToArabic(string roman, int expectedArabic)
        {
            var converter = new ARConverter();
            converter
            .convertTo(roman)
            .Should()
            .Be(expectedArabic);
        }


        [Theory]
        [InlineData(2019, "MMXIX")]
        [InlineData(1994, "MCMXCIV")]
        [InlineData(1949, "MCMXLIX")]
        [InlineData(1494, "MCDXCIV")]
        [InlineData(500, "D")]
        [InlineData(1, "I")]
        [InlineData(3999, "MMMCMXCIX")]
        public void TestToRoman(int arabic, string expectedRoman)
        {
            var converter = new ARConverter();
            converter
            .convertFrom(arabic)
            .Should()
            .Be(expectedRoman);
        }

        [Fact]
        public void ShouldThrowArgumentExceptionCaseOfWrongRomanNumberal()
        {
            checkToArabicThrowArgumentException("GXHL");
        }

        [Fact]
        public void ShouldThrowArgumentExceptionCaseOfInvalidRomanNumberal()
        {
            checkToArabicThrowArgumentException("MCCIVMX");
        }

        [Fact]
        public void ShouldThrowArgumentExceptionCaseOfTooBigArabicNumber()
        {
            checkToRomanThrowArgumentException(4000);
        }

        [Fact]
        public void ShouldThrowArgumentExceptionCaseOfWrongArabicNumber()
        {
            checkToRomanThrowArgumentException(-1);
        }

        private static void checkToArabicThrowArgumentException(string roman)
        {
            var converter = new ARConverter();

            converter.Invoking(obj =>
            {
                var unused = obj.convertTo(roman);
            })
              .Should()
              .Throw<ArgumentException>();
        }

        private static void checkToRomanThrowArgumentException(int arabic)
        {
            var converter = new ARConverter();
            converter.Invoking(obj =>
            {
                var unused = obj.convertFrom(arabic);
            })
              .Should()
              .Throw<ArgumentException>();
        }
    }
}
