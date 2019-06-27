using ArabicRomanConverter.Absraction;
using System;

namespace ArabicRomanConverter.Implementation
{
    public static class ConverterFactory
    {
        public static IConverter<T, K> Build<T, K>()
        {
            if (typeof(T) == typeof(string) && typeof(K) == typeof(int))
            {
                return (IConverter<T, K>) new ARConverter();
            }
            throw new ArgumentException("Unsupported converter type");
        }
    }
}
