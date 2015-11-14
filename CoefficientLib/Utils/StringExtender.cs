using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoefficientLib.Utils
{
    public static class StringExtender
    {
        public static string TrimOrEmpty(this string s)
        {
            if (s == null)
                return string.Empty;

            return s.Trim();
        }
    }
}
