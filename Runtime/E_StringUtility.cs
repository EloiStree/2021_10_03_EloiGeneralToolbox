using System;
using System.Text.RegularExpressions;

namespace Eloi
{
    public class E_StringUtility
    {
        public static readonly string abc = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly string Num ="0123456789";
        public static readonly string AlphaNum="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

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

        public static void Capitalize(in string text, out string result)
        {
            //source=https://stackoverflow.com/questions/913090/how-to-capitalize-the-first-character-of-each-word-or-the-first-character-of-a
            result = Regex.Replace(text, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
        }

        public static bool IsNullOrEmpty( in string t)
        {
            return !IsFilled(t);
        }

        public static void ConvertToAlphaNumByReplacing(in string text, out string textResult, in string replaceNoneAlphaby="_")
        {
            Regex rgx = new Regex("[^a-zA-Z0-9_]");
            textResult = rgx.Replace(text, replaceNoneAlphaby);
        }

        public static void Clamp(in string givenText, out string clampText, in uint maxChar=32)
        {
            if (givenText.Length < maxChar)
                clampText = givenText;
            else 
               clampText = givenText.Substring(0, (int)maxChar);
        }

        public static bool StartWith(in string text, in string line, in bool useLower, in bool useTrim)
        {
            if (text.Length < line.Length)
                return false;
            string textStart = text.Substring(0, line.Length);

            bool textDefined= textStart != null && textStart.Length > 0;
            bool lineDefined= line != null && line.Length > 0;
            if ( !textDefined || !lineDefined) {
                return !textDefined == !lineDefined;
            }
           

          return  AreEquals(in line, textStart, true, true);

        }

        public class Mail { 
            //private static readonly string notWantedCharInMail = "!#$%&'*+-/=?^_`{|}~";//19
            //private static readonly string notWantedCharSaveEquivalent = "♚♟♞♙♘♖♕♔♜♛♗♝♤♡♧♢←↑→";//19
            //public static void MaskSpecialCharOfEmail(string mail, out string maskedMail)
            //{
            //    char[] mailAsChar = mail.ToCharArray();
            //    for (int i = 0; i < mailAsChar; i++)
            //    {
            //        for (int i = 0; i < notWantedCharInMail; i++)
            //        {

            //        }
            //        if(mailAsChar[i]==)

            //    }
            //}
        }
        public static bool AreFilled(in string a, in string b, in bool ignoreCase, in bool useTrim)
        {
            return IsFilled(in a) && IsFilled(b);
        }
        public static bool AreEquals(in string a, in string b, in bool ignoreCase, in bool useTrim)
        {
            
            if (a == null && b == null)
                return true;
            if ((a != null && b == null) 
                || (a == null && b != null))
                return false;

            if (!ignoreCase && !useTrim)
            {

                if (a.Length == b.Length && a.IndexOf(b) == 0)
                    return true;
            }
            else {
                string ta=a, tb=b;
                if (ignoreCase)
                {
                    ta = ta.ToLower();
                    tb = tb.ToLower();
                }
                if (useTrim)
                {
                    ta = ta.Trim();
                    tb = tb.Trim();
                }
                if (ta.Length == tb.Length && ta.IndexOf(tb) == 0)
                    return true;
            }
            
            return false;
        }

        public static void SplitInTwo(in string text, in  int charIndex, out string leftPart, out string rightPart)
        {
            if (!E_StringUtility.IsFilled(text) || text.Length < 1)
                E_ThrowException.ThrowNotMyProblemException("Eloi", "Text can't be null, empty or too short");
            if (charIndex<0)
                E_ThrowException.ThrowNotMyProblemException("Eloi", "You need to give a index to split the text with");
            leftPart = text.Substring(0, charIndex);
            rightPart = text.Substring(charIndex+1);
        }
    }
}