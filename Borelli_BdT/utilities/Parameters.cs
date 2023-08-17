using System;
using System.Collections.Generic;
using System.IO;
using Borelli_BdT.model;

namespace Borelli_BdT.utilities {
    public /*static*/ class Parameters {
        private static string _FPUsers, _FPTasks, _FPDistricts, _FPJobs;
        private static float _deltaPercentage;

        private static string _parametersPath;

        //li ri-dichiaro non statici per poterli leggere da file Json e associarli successivamente a quelli statici
        public string FilePathUser { get; private set; }
        public string FilePathTasks { get; private set; }
        public string FilePathDistricts { get; private set; }
        public string FilePathJobs { get; private set; }
        public float DeltaPerc { get; private set; }

        public Parameters(string filePathUser, string filePathTasks, string filePathDistricts, string filePathJobs, float deltaPerc) {
            FilePathUser = filePathUser;
            FilePathTasks = filePathTasks;
            FilePathDistricts = filePathDistricts;
            FilePathJobs = filePathJobs;
            DeltaPerc = deltaPerc;
        }

        public static void Init(string path) {
            ParametersPath = path;
            Parameters tmp = FileManager.ReadParametersFile(ParametersPath);

            FPUsers = tmp.FilePathUser;
            FPTasks = tmp.FilePathTasks;
            FPDistricts = tmp.FilePathDistricts;
            FPJobs = tmp.FilePathJobs;
            DeltaPercentage = tmp.DeltaPerc;
        }

        private static string ParametersPath {
            get => _parametersPath;
            set => DataChecker.SetIfValidString(ref _parametersPath, value, "Inserire un path valido", CheckStr.Generic);
        }
        public static string FPUsers {
            get => _FPUsers;
            private set {
                if (!DataChecker.IsValidString(value, CheckStr.Generic))
                    throw new Exception("Inserire un percorso file per il file 'users.json' valido");

                _FPUsers = value;
            }
        }

        public static string FPTasks {
            get => _FPTasks;
            private set {
                if (!DataChecker.IsValidString(value, CheckStr.Generic))
                    throw new Exception("Inserire un percorso file per il file 'tasks.json' valido");

                _FPTasks = value;
            }
        }

        public static string FPDistricts {
            get => _FPDistricts;
            private set {
                if (!DataChecker.IsValidString(value, CheckStr.Generic))
                    throw new Exception("Inserire un percorso file per il file 'districts.json' valido");

                _FPDistricts = value;
            }
        }

        public static string FPJobs {
            get => _FPJobs;
            private set {
                if (!DataChecker.IsValidString(value, CheckStr.Generic))
                    throw new Exception("Inserire un percorso file per il file 'jobs.json' valido");

                _FPJobs = value;
            }
        }
        public static float DeltaPercentage {
            get => _deltaPercentage;
            private set => DataChecker.SetIfValidNumber(ref _deltaPercentage, value, "Inserire una percentuale [0-100]", CheckNumb.Percentage);
        }

        public static void WriteJsonFile() {
            Parameters p = new Parameters(FPUsers, FPTasks, FPDistricts, FPJobs, DeltaPercentage);
            FileManager.WriteJsonFile(p, ParametersPath);
        }
    }
}
