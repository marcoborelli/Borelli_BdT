using System;
using System.Collections.Generic;
using Borelli_BdT.utilities;

namespace Borelli_BdT.model {
    public static class Jobs {
        public static List<string> Works { get; private set; }

        public static void Init() {
            FileManager.CheckJobsFile();
            Works = new List<string>(FileManager.ReadJsonFile<List<string>>(Parameters.FPJobs));
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
            FileManager.WriteJsonFile(Works, Parameters.FPJobs);
        }
    }
}
