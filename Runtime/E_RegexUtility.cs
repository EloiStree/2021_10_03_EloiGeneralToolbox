using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Eloi
{
    public class E_RegexUtility
    {

        public static void IsMailAddress(in string mail, out bool isMailAddress)
        {
            string mailValue = mail.Trim();
            Regex r = new Regex("^(?(\")(\".+?(?<!\\\\)\"@) |(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$");
            Match m = r.Match(mailValue);
            bool isMailAddressRegex = m.Success && m.Value.Length == mailValue.Length;
            int arrobasIndex = mail.LastIndexOf("@");
            int dotIndex = mail.LastIndexOf(".");
            bool hasMinimum = arrobasIndex > 0 && dotIndex > 0 && dotIndex > arrobasIndex;
            isMailAddress = isMailAddressRegex && hasMinimum;

            //    // Should be done with Regex, but not the time now:
            ////https://stackoverflow.com/questions/201323/how-can-i-validate-an-email-address-using-a-regular-expression
            //try
            //{
            //    MailAddress m = new MailAddress(mail);

            //    isMailAddress = true;
            //}
            //catch (FormatException)
            //{
            //    isMailAddress = false;
            //}

        }
    }
}