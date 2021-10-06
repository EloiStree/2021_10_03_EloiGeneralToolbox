using System;

namespace Eloi
{
    public class E_StringUtility
    {
        public static bool IsFilled(in string text)
        {
            if (text == null)
                return false;
            if (text.Length<=0)
                return false;
            if (string.IsNullOrWhiteSpace(text)) {
                return false;
            }
            return true;

        }

        public static bool IsNullOrEmpty( in string t)
        {
            return !IsFilled(t);
        }
    }
}