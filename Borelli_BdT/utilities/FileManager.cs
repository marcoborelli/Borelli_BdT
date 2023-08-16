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

            return outp;
        }
        public static List<User> ReadUsersFile(string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            string text = File.ReadAllText(filePath);
            List<User> outp = JsonConvert.DeserializeObject<List<User>>(text);

            return outp;
        }
        public static List<model.Task> ReadTasksFile(string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            string text = File.ReadAllText(filePath);
            List<model.Task> outp = JsonConvert.DeserializeObject<List<model.Task>>(text);

            return outp;
        }
        public static Parameters ReadParametersFile(string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            string text = File.ReadAllText(filePath);
            Parameters outp = JsonConvert.DeserializeObject<Parameters>(text);

            return outp;
        }


        public static void WriteStringFile(List<string> input, string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            if (input == null)
                throw new Exception("Inserire una lista di stringhe valida");


            string text = JsonConvert.SerializeObject(input, Formatting.Indented);
            WriteFile(filePath, text);
        }
        public static void WriteUsersFile(List<User> input, string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            if (input == null)
                throw new Exception("Inserire una lista di User valida");


            string text = JsonConvert.SerializeObject(input, Formatting.Indented);
            WriteFile(filePath, text);
        }
        public static void WriteTasksFile(List<model.Task> input, string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");

            if (input == null)
                throw new Exception("Inserire una lista di User valida");


            string text = JsonConvert.SerializeObject(input, Formatting.Indented);
            WriteFile(filePath, text);
        }
        public static void WriteParamtersFile(string filePath) {
            if (!File.Exists(filePath))
                throw new Exception("Inserire un file path valido");


            Parameters p = new Parameters(Parameters.FPUsers, Parameters.FPTasks, Parameters.FPDistricts, Parameters.FPJobs, Parameters.DeltaPercentage);
            string text = JsonConvert.SerializeObject(p, Formatting.Indented);
            WriteFile(filePath, text);
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
