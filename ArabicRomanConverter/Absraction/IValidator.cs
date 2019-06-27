using System;
using System.Collections.Generic;
using System.Text;

namespace ArabicRomanConverter.Absraction
{
    public interface IValidator<T, K>
    {
        bool validateTo(T roman);

        bool validateFrom(K arabic);
    }
}
