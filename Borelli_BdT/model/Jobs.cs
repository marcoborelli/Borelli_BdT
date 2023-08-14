using System;
using System.Collections.Generic;

namespace Borelli_BdT.model {
    public static class Jobs {
        private static List<string> Works { get; set; }

        public static void Init() {
            Works = new List<string>();
            //TODO: ClasseJson.Carica(filename);
        }
        public static void AddJob(string j) {
            if (Works == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica Job");

            j = j.Trim().ToUpper();

            if (Works.Contains(j))
                throw new Exception("Il lavoro è già esistente");

            Works.Add(j);
        }

        public static void RemoveJob(string j) {
            if (Works == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica Job");

            j = j.Trim().ToUpper();
            int index = Works.IndexOf(j);

            if (index == -1)
                throw new Exception("Il lavoro non è presente nella lista");

            Works.RemoveAt(index);
        }

        public static bool IsJobValid(string j) {
            if (Works == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica Job");

            j = j.Trim().ToUpper();
            return Works.Contains(j);
        }

        public static void WriteJsonFile() {
            //TODO: ClasseJson.WriteFile(Works);
        }
    }
}
