using System;
using System.Collections.Generic;
using System.Text;

namespace ArabicRomanConverter.Absraction
{
    public interface IConverter<T, K>
    {
        K convertTo(T roman);

        T convertFrom(K arabic);
    }
}
