using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borelli_BdT.model;

namespace Borelli_BdT.presenter {
    public class EntityCustomerMasterData {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }

        public static EntityCustomerMasterData GetEntity(CustomerMasterData data) {
            EntityCustomerMasterData e = new EntityCustomerMasterData {
                Field1 = data.Name,
                Field2 = data.Surname,
                Field3 = data.PhoneNumber,
                Field4 = data.Email,
                Field5 = data.HomeAddress,
                Field6 = data.District,
                Field7 = $"{data.BirthDate}"
            };

            return e;
        }

        public static CustomerMasterData GetCustomerMasterData(EntityCustomerMasterData e) {
            return new CustomerMasterData(e.Field1, e.Field2, e.Field3, e.Field4, e.Field5, e.Field6, DateTime.Parse(e.Field7));
        }

        public static string[] GetEntityFieldNames() {
            return new string[] { "NOME", "COGNOME", "NUM. TELEFONO", "EMAIL", "INDIRIZZO CASA", "QUARTIERE", "DATA NASCITA" };
        }
    }
}
