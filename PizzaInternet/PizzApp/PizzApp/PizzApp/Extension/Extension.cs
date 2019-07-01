using System;
using System.Collections.Generic;
using System.Text;

namespace PizzApp.Extension
{
    public static class StringExtension
    {
        public static string PremiereLettreMajuscule(this string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }

            string ret = str.ToLower();

            ret = ret.Substring(0, 1).ToUpper() + ret.Substring(1, str.Length - 1);

            return ret;
        }
    }
}
