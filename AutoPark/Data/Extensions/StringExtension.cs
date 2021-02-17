using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Data.Extensions
{
    public static class StringExtension
    {
        public static string Center(this string source, int count, char separator)
        {
            var stringBuilder = new StringBuilder(source, source.Length + count);
            for (var i = 0; i < count; i++)
            {
                if (i < (count / 2) - 1)
                {
                    stringBuilder.Insert(0, separator);
                }
                else
                {
                    stringBuilder.Append(separator);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
