using System;
using System.Text.RegularExpressions;

namespace BankApp.Common
{
    public static class Validation
    {
        /// <summary>
        /// validates customer Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValidateName(string name)
        {
            Regex re = new Regex("^[A-Z]{1}[a-z]+$");
            if (!string.IsNullOrWhiteSpace(name) || !string.IsNullOrWhiteSpace(name))
                if (re.IsMatch(name) && re.IsMatch(name))
                    return true;

            return false;
        }


        /// <summary>
        /// validate customer email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidateEmail(string email)
        {
            //Regex regrex = new Regex(@"^[a-zA-Z0-9+_.-]+[@]{1}[a-z]+[.]{1}[a-z]+$");
            Regex regrex = new Regex(@"^[a-zA-Z0-9_.]+[@]{1}[a-z]+[.]{1}[a-z]+$");
            if (!regrex.IsMatch(email))
                return false;
            return true;
        }


        /// <summary>
        /// validate customer password
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static bool ValidatePassword(string passWord)
        {
            Regex re = new Regex(@"^(?=.*[a-zA-Z])(?=.*)(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$");
            if (!re.IsMatch(passWord))
                return false;
            return true;
        }


        /// <summary>
        /// validate customer phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            //Regex re = new Regex(@"^[0]\d{10}$");
            if (phoneNumber.ToString().Length < 11 || phoneNumber.ToString().Length > 11)
                return false;
            Regex re = new Regex(@"^[0-9]{11}$");
            if (!re.IsMatch(phoneNumber.ToString()))
                return false;
            return true;
        }
    }
}
