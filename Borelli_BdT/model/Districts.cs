using System;
using System.Collections.Generic;
using Borelli_BdT.utilities;

namespace Borelli_BdT.model {
    public static class Districts {
        public static List<string> Zones { get; private set; }

        public static void Init() {
            FileManager.CheckDistrictFile(Parameters.FPDistricts);
            Zones = new List<string>(FileManager.ReadJsonFile<List<string>>(Parameters.FPDistricts));
        }
        public static void AddDistrict(string d) {
            if (Zones == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica Districts");

            d = d.Trim().ToUpper();

            if (Zones.Contains(d))
                throw new Exception("La zona è già esistente");

            Zones.Add(d);
        }

        public static void RemoveDistrict(string d) {
            if (Zones == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica Districts");

            d = d.Trim().ToUpper();
            int index = Zones.IndexOf(d);

            if (index == -1)
                throw new Exception("La zona non è presente nella lista");

            Zones.RemoveAt(index);
        }

        public static bool IsDistrictValid(string d) {
            if (Zones == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica Districts");

            d = d.Trim().ToUpper();
            return Zones.Contains(d);
        }

        public static void WriteJsonFile() {
            FileManager.WriteJsonFile(Zones, Parameters.FPDistricts);
        }
    }
}
