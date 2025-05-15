using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoCms6
{

    public static class StringExtensions
    {
        public static string ToBase64(this object data)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(data.ToString())).TrimEnd('=').Replace('+', '-');

        public static string ToBase64(this int data)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(data.ToString())).TrimEnd('=').Replace('+', '-');

        public static int IntegerFromBase64(this object data) 
            => int.Parse(StringFromBase64(data.ToString()));

        public static string StringFromBase64(this string data)
        {
            var text = data.ToString().Replace('_', '/').Replace('-', '+');
            switch (text.Length % 4)
            {
                case 2:
                    text += "==";
                    break;
                case 3:
                    text += "=";
                    break;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }
    }
}
