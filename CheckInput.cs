using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ASM2
{
    public class CheckInput
    {
        private bool Length(string input)
        {
            if (input.Length != 1)
                return false;
            return true;
        }

        private bool Just_number(string input)
        {
            foreach (Char c in input)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool Date_Time(string takeDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(takeDate, out tempDate);
        }
        public bool Validation_Switch(string input)
        {
            if ((Length(input) == false) || (Just_number(input) == false))
                return false;
            return true;
        }
        public int unduplicated(string ID, string newID)
        {
            if (newID != ID)
            {
                return 0;
            }
            return -1;
        }
        public int Isid(string ID)
        {
            if (ID.Length == 7)
            {
                if (ID.StartsWith("GT") || ID.StartsWith("GX"))
                {
                    string str = ID.Substring(2);
                    if (Only_Digit(str) == true)
                    {
                        return 0;
                    }
                }
            }
            if (ID.Length == 8)
            {
                if (Only_Digit(ID) == true)
                {
                    return 0;
                }
            }

            return -1;
        }
        public int Is_Gmail(string gmail)
        {
            string EmailFormat = "@gmail.com";
            if (gmail.Contains(EmailFormat))
            {
                return 0;
            }
            return -1;
        }
        public int Check_specialCharacters(string input)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(input))
            {
                return 0;
            }
            return -1;
        }
        public int NotNull(string input)
        {
            if (input == null || input == "")
            {
                return -1;
            }
            return 0;
        }
        public bool Only_Digit(string s)
        {
            foreach (char item in s)
            {
                if (item < '0' || item > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}