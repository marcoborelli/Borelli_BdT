using System;
using System.Text.RegularExpressions;

namespace Borelli_BdT.utilities {
    public enum CheckStr {
        Generic,
        PhoneNumber,
        Email,
        District,
    }
    public enum CheckDate {
        Adult,
    }
    public static class DataChecker {
        public static void SetIfValidString(ref string field, string val, string errorMessage, CheckStr whatCheck) {
            bool valid = false;

            switch (whatCheck) {
                case CheckStr.Generic:
                    if (!String.IsNullOrWhiteSpace(val)) {
                        valid = true;
                    }
                    break;
                case CheckStr.PhoneNumber:
                    Regex rxPhoneNumb = new Regex(@"^(\+\d{1,2}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$");
                    valid = rxPhoneNumb.IsMatch(val);
                    break;
                case CheckStr.Email:
                    Regex rxEmail = new Regex(@"@[a-zA-Z]+\.[a-zA-Z]+$");
                    valid = rxEmail.IsMatch(val);
                    break;
                case CheckStr.District:
                    //TODO: valid = Districts.IsDistrictValid(val);
                    break;
            }
            //in questo modo mi risparmio di controllare a ogni case ma faccio una condizione riassuntiva
            field = valid ? val : throw new Exception($"{errorMessage}");
        }
        public static void SetIfValidDate(ref DateTime field, DateTime val, string errorMessage, CheckDate whatCheck) {
            bool valid = false;

            switch (whatCheck) {
                case CheckDate.Adult:
                    if (DateTime.Now.Year - val.Year < 18) {
                        valid = true;
                    }
                    break;
            }

            field = valid ? val : throw new Exception($"{errorMessage}");
        }
    }
}
