﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Borelli_BdT.model;

namespace Borelli_BdT.utilities {
    public enum CheckStr {
        Generic,
        PhoneNumber,
        Email,
        District,
        Work,
        Nickname,
    }
    public enum CheckStrList {
        Generic,
        District,
        Work,
    }


    public enum CheckDate {
        Adult,
    }


    public enum CheckNumb {
        Stars,
        Positive,
        Percentage,
    }

    public static class DataChecker {
        public static void SetIfValidString(ref string field, string val, string errorMessage, CheckStr whatCheck) {
            bool valid = IsValidString(val, whatCheck);

            field = valid ? val : throw new Exception($"{errorMessage}");
        }

        public static bool IsValidString(string val, CheckStr whatCheck) {
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
                    valid = Districts.IsDistrictValid(val);
                    break;
                case CheckStr.Work:
                    valid = Jobs.IsJobValid(val);
                    break;
                case CheckStr.Nickname:
                    //TODO: controllare che il nickname sia davvero associato ad un utente
                    valid = true;
                    break;
            }

            return valid;
        }
        public static void SetIfValidDate(ref DateTime field, DateTime val, string errorMessage, CheckDate whatCheck) {
            bool valid = IsValidDate(val, whatCheck);

            field = valid ? val : throw new Exception($"{errorMessage}");
        }

        public static bool IsValidDate(DateTime val, CheckDate whatCheck) {
            bool valid = false;

            switch (whatCheck) {
                case CheckDate.Adult:
                    if (DateTime.Now.Year - val.Year >= 18) {
                        valid = true;
                    }
                    break;
            }

            return valid;
        }

        public static void SetIfListStrValid(ref List<string> dst, List<string> val, string errorMessage, CheckStrList whatCheck) {
            bool valid = false;

            switch (whatCheck) {
                case CheckStrList.Generic:
                    for (int i = 0; i < val.Count; i++) {
                        if (!IsValidString(val[i], CheckStr.Generic))
                            break;

                        if (i == val.Count - 1)
                            valid = true;
                    }
                    break;
                case CheckStrList.District:
                    for (int i = 0; i < val.Count; i++) {
                        if (!IsValidString(val[i], CheckStr.District))
                            break;

                        if (i == val.Count - 1)
                            valid = true;
                    }
                    break;
                case CheckStrList.Work:
                    for (int i = 0; i < val.Count; i++) {
                        if (!IsValidString(val[i], CheckStr.Work))
                            break;

                        if (i == val.Count - 1)
                            valid = true;
                    }
                    break;
            }

            dst = valid ? val : throw new Exception($"{errorMessage}");
        }

        public static void SetIfValidNumber(ref float field, float val, string errorMessage, CheckNumb whatCheck) {
            bool valid = IsValidNumber(val, whatCheck);

            field = valid ? val : throw new Exception($"{errorMessage}");
        }

        public static bool IsValidNumber(float val, CheckNumb whatCheck) {
            bool valid = false;

            switch (whatCheck) {
                case CheckNumb.Stars:
                    if (val >= 0 && val <= 5) {
                        valid = true;
                    }
                    break;
                case CheckNumb.Positive:
                    if (val >= 0) {
                        valid = true;
                    }
                    break;
                case CheckNumb.Percentage:
                    if (val <= 100 && val >= 0) {
                        valid = true;
                    }
                    break;
            }

            return valid;
        }
    }
}
