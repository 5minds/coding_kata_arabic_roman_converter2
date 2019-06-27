using ArabicRomanConverter.Absraction;
using System;

namespace ArabicRomanConverter.Implementation
{
    public static class ValidatorFactory
    {
        public static IValidator<T, K> Build<T, K>()
        {
            if (typeof(T) == typeof(string) && typeof(K) == typeof(int))
            {
                return (IValidator<T, K>) new ARValidator();
            }
            throw new ArgumentException("Unsupported converter type");

        }
    }
}
