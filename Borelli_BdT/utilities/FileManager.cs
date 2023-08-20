using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Borelli_BdT.model;

namespace Borelli_BdT.utilities {
    public static class FileManager {

        public static T ReadJsonFile<T>(string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            string text = File.ReadAllText(filePath);
            T outp = JsonConvert.DeserializeObject<T>(text);


            if (outp == null) { //peche' in ogni caso io la lista la devo inizializzare, non puo' stare null
                outp = (T)Activator.CreateInstance(typeof(T));
            }

            return outp;
        }

        public static void WriteJsonFile<T>(T input, string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            if (input == null)
                throw new Exception("Inserire un input valido");


            string text = JsonConvert.SerializeObject(input, Formatting.Indented);
            WriteFile(filePath, text);
        }


        public static void CheckDistrictFile() {
            if (!File.Exists(Parameters.FPDistricts)) {
                CreateFile(Parameters.FPDistricts);

                List<string> defaultDistricts = new List<string> { "CENTRO", "CAPPUCCINI", "INDUSTRIALE" };
                WriteJsonFile(defaultDistricts, Parameters.FPDistricts);
            }
        }

        public static void CheckJobsFile() {
            if (!File.Exists(Parameters.FPJobs)) {
                CreateFile(Parameters.FPJobs);

                List<string> defaultJobs = new List<string> { "SEGRETERIA", "IDRAULICA", "MECCANICA", "BADANTE" };
                WriteJsonFile(defaultJobs, Parameters.FPJobs);
            }
        }

        public static void CheckTasksFile() {
            if (!File.Exists(Parameters.FPTasks)) {
                CreateFile(Parameters.FPTasks);
            }
        }
        public static void CheckUsersFile() {
            if (!File.Exists(Parameters.FPUsers)) {
                CreateFile(Parameters.FPUsers);
                User u = new User("DummyName", "DummySurname", "1234567789", "mail@dummy.it", "Via AAA", "CENTRO",
                     new DateTime(2000, 1, 1), "DummyNickName", "password", new List<string> { "SEGRETERIA" },
                     new List<string> { "CENTRO" }, RegContext.Confirmed);

                WriteJsonFile(new List<User> { u }, Parameters.FPUsers);
            }
        }
        public static void CheckParametersFile() {
            if (!File.Exists(Parameters.ParametersPath)) {
                CreateFile(Parameters.ParametersPath);
                Parameters p = new Parameters("data", 12);

                WriteJsonFile(p, Parameters.ParametersPath);
            }
        }

        public static void CheckFolder(string path) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
        }

        public static void CreateFile(string filePath) {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)) {
            }
        }

        public static void WriteFile(string filePath, string text) {
            using (StreamWriter writer = new StreamWriter(filePath, false)) {
                writer.Write(text);
            }
        }
    }
}
