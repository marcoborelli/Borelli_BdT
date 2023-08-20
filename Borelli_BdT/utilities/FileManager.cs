using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Borelli_BdT.model;

namespace Borelli_BdT.utilities {
    public static class FileManager {
        public static List<string> ReadStringFile(string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            string text = File.ReadAllText(filePath);
            List<string> outp = JsonConvert.DeserializeObject<List<string>>(text);

            if (outp == null)
                outp = new List<string>();
            return outp;
        }
        public static List<User> ReadUsersFile(string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            string text = File.ReadAllText(filePath);
            List<User> outp = JsonConvert.DeserializeObject<List<User>>(text);

            if (outp == null)
                outp = new List<User>();
            return outp;
        }
        public static List<model.Task> ReadTasksFile(string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            string text = File.ReadAllText(filePath);
            List<model.Task> outp = JsonConvert.DeserializeObject<List<model.Task>>(text);

            if (outp == null)
                outp = new List<Task>();
            return outp;
        }
        public static Parameters ReadParametersFile(string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            string text = File.ReadAllText(filePath);
            Parameters outp = JsonConvert.DeserializeObject<Parameters>(text);

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


        public static void CheckDistrictFile(string filePath) {
            if (!File.Exists(Parameters.FPDistricts)) {
                CreateFile(Parameters.FPDistricts);

                List<string> defaultDistricts = new List<string> { "CENTRO", "CAPPUCCINI", "INDUSTRIALE" };
                WriteJsonFile(defaultDistricts, filePath);
            }
        }

        public static void CheckJobsFile(string filePath) {
            if (!File.Exists(Parameters.FPJobs)) {
                CreateFile(Parameters.FPJobs);

                List<string> defaultJobs = new List<string> { "SEGRETERIA", "IDRAULICA", "MECCANICA", "BADANTE" };
                WriteJsonFile(defaultJobs, filePath);
            }
        }

        public static void CheckTasksFile(string filePath) {
            if (!File.Exists(Parameters.FPTasks)) {
                CreateFile(filePath);
            }
        }
        public static void CheckUsersFile(string filePath) {

            if (!File.Exists(Parameters.FPUsers)) {
                CreateFile(Parameters.FPUsers);
                User u = new User("DummyName", "DummySurname", "1234567789", "mail@dummy.it", "Via AAA", "CENTRO",
                     new DateTime(2000, 1, 1), "DummyNickName", "password", new List<string> { "SEGRETERIA" },
                     new List<string> { "CENTRO" }, RegContext.Confirmed);

                WriteJsonFile(new List<User> { u }, filePath);
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
