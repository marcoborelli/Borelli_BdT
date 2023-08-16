using System;
using Borelli_BdT.utilities;
using Newtonsoft.Json;

namespace Borelli_BdT.model {
    public class CustomerMasterData {
        private string _name, _surname, _phoneNumb, _email, _homeAddress, _district;
        private DateTime _bithDate;

        public CustomerMasterData() { //solo per Newtonsoft.Json
        }
        public CustomerMasterData(string name, string surname, string phoneNumb, string email, string homeAddress, string district, DateTime birthDate) {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumb;
            Email = email;
            HomeAddress = homeAddress;
            District = district;
            BirthDate = birthDate;
        }

        [JsonProperty]
        public string Name {
            get => _name;
            private set => DataChecker.SetIfValidString(ref _name, value, "Inserire un nome valido", CheckStr.Generic);
        }
        [JsonProperty]
        public string Surname {
            get => _surname;
            private set => DataChecker.SetIfValidString(ref _surname, value, "Inserire un cognome valido", CheckStr.Generic);
        }
        [JsonProperty]
        public string PhoneNumber {
            get => _phoneNumb;
            private set => DataChecker.SetIfValidString(ref _phoneNumb, value, "Inserire un numero di telefono valido", CheckStr.PhoneNumber);
        }
        [JsonProperty]
        public string Email { //PK
            get => _email;
            private set => DataChecker.SetIfValidString(ref _email, value, "Inserire una mail valida", CheckStr.Email);
        }
        [JsonProperty]
        public string HomeAddress {
            get => _homeAddress;
            private set => DataChecker.SetIfValidString(ref _homeAddress, value, "Inserire un indirizzo di casa valido", CheckStr.Generic);
        }
        [JsonProperty]
        public string District {
            get => _district;
            private set => DataChecker.SetIfValidString(ref _district, value, "Il quartiere indicato non è riconosciuto", CheckStr.District);
        }
        [JsonProperty]
        public DateTime BirthDate {
            get => _bithDate;
            private set => DataChecker.SetIfValidDate(ref _bithDate, value, "Bisogna essere maggiorenni per registrarsi", CheckDate.Adult);
        }
    }
}
