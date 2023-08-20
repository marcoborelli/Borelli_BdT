using System;

namespace Borelli_BdT.utilities {
    public /*static*/ class Parameters {
        private static float _deltaPercentage;
        private static string _parametersPath, _DPBase;
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

        public static void Init(string path) {
            ParametersPath = path;

            Parameters tmp = FileManager.ReadParametersFile(ParametersPath);

            DPBase = tmp.BasePath;
            DeltaPercentage = tmp.DeltaPerc;

            FPUsers = $"{DPBase}/users.json";
            FPTasks = $"{DPBase}/tasks.json";
            FPDistricts = $"{DPBase}/districts.json";
            FPJobs = $"{DPBase}/jobs.json";
            DPPictures = $"{DPBase}/pictures";
        }



        private static string ParametersPath {
            get => _parametersPath;
            set => DataChecker.SetIfValidString(ref _parametersPath, value, "Inserire un path valido", CheckStr.Generic);
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
    }
}
