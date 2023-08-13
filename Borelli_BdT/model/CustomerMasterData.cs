using System;
using Borelli_BdT.utilities;

namespace Borelli_BdT.model {
    public enum Context {
        Registration,
        Confirmed
    }
    internal class CustomerMasterData {
        private string _name, _surname, _phoneNumb, _email, _homeAddress, _district;
        private DateTime _bithDate;
        public Context State { get; private set; }

        public string Name {
            get => _name;
            private set => DataChecker.SetIfValidString(ref _name, value, "Inserire un nome valido", CheckStr.Generic);
        }
        public string Surname {
            get => _surname;
            private set => DataChecker.SetIfValidString(ref _surname, value, "Inserire un cognome valido", CheckStr.Generic);
        }
        public string PhoneNumber {
            get => _phoneNumb;
            private set => DataChecker.SetIfValidString(ref _phoneNumb, value, "Inserire un numero di telefono valido", CheckStr.PhoneNumber);
        }
        public string Email { //PK
            get => _email;
            private set => DataChecker.SetIfValidString(ref _email, value, "Inserire una mail valida", CheckStr.Email);
        }
        public string HomeAddress {
            get => _homeAddress;
            private set => DataChecker.SetIfValidString(ref _homeAddress, value, "Inserire un indirizzo di casa valido", CheckStr.Generic);
        }
        public string District {
            get => _district;
            private set {
                switch (State) {
                    case Context.Registration:
                        DataChecker.SetIfValidString(ref _district, value, "Inserire un valore valido come quartiere", CheckStr.Generic);
                        break;
                    case Context.Confirmed:
                        DataChecker.SetIfValidString(ref _district, value, "Il quartiere indicato non è riconosciuto", CheckStr.District);
                        break;
                }
            }
        }
        public DateTime BirthDate {
            get => _bithDate;
            private set => DataChecker.SetIfValidDate(ref _bithDate, value, "Bisogna essere maggiorenni per registrarsi", CheckDate.Adult);
        }

        public CustomerMasterData(string name, string surname, string phoneNumb, string email, string district, DateTime birthDate, Context step) {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumb;
            Email = email;
            District = district;
            BirthDate = birthDate;
            State = step;
        }
    }
}
