using System;

namespace Borelli_BdT.utilities {
    public class Parameters {
        private static float _deltaPercentage;
        private static string _DPBase;
        public static string ParametersPath { get; private set; }
        public static string FPUsers { get; private set; }
        public static string FPTasks { get; private set; }
        public static string FPDistricts { get; private set; }
        public static string FPJobs { get; private set; }
        public static string DPPictures { get; private set; }


        //li ri-dichiaro non statici per poterli leggere da file Json e associarli successivamente a quelli statici
        public string BasePath { get; private set; }
        public float DeltaPerc { get; private set; }

        public Parameters(string basePath, float deltaPerc) {
            BasePath = basePath;
            DeltaPerc = deltaPerc;
        }

        public static void Init() {
            ParametersPath = "parameters.json";
            FileManager.CheckParametersFile();

            Parameters tmp = FileManager.ReadJsonFile<Parameters>(ParametersPath);

            DPBase = tmp.BasePath;
            FileManager.CheckFolder(DPBase);
            DeltaPercentage = tmp.DeltaPerc;

            FPUsers = $"{DPBase}/users.json";
            FPTasks = $"{DPBase}/tasks.json";
            FPDistricts = $"{DPBase}/districts.json";
            FPJobs = $"{DPBase}/jobs.json";
            DPPictures = $"{DPBase}/pictures";
        }



        public static string DPBase {
            get => _DPBase;
            private set => DataChecker.SetIfValidString(ref _DPBase, value, "Inserire un nome per la cartella bse valido", CheckStr.Generic);
        }

        public static float DeltaPercentage {
            get => _deltaPercentage;
            private set => DataChecker.SetIfValidNumber(ref _deltaPercentage, value, "Inserire una percentuale [0-100]", CheckNumb.Percentage);
        }



        public static void WriteJsonFile() {
            Parameters p = new Parameters(DPBase, DeltaPercentage);
            FileManager.WriteJsonFile(p, ParametersPath);
        }

        public static string GetCompleteImagePath(string username) {
            return $"{Parameters.DPPictures}/{username}.jpg";
        }
    }
}
