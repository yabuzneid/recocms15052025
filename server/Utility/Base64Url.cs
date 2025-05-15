﻿using System;
using System.Text;

namespace RecoCms6.Utility;

public static class Base64Url
{

    public static string Encode(this string text)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).TrimEnd('=').Replace('+', '-')
            .Replace('/', '_');
    }

    public static string Decode(this string text)
    {
        text = text.Replace('_', '/').Replace('-', '+');
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