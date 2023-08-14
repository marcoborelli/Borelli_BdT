using System;
using System.Collections.Generic;
using System.IO;

namespace Borelli_BdT.utilities {
    public /*static*/ class Parameters {
        private static string _FPUsers, _FPTasks, _FPDistricts, _FPJobs;
        private static float _deltaPercentage;


        public static void Init(string path) {
            //TODO: ClasseJson.Carica();
        }
        public static string FPUsers {
            get => _FPUsers;
            private set {
                if (!DataChecker.IsValidString(value, CheckStr.Generic))
                    throw new Exception("Inserire un percorso file per il file 'users.json' valido");

                _FPUsers = value;

                if (!File.Exists(FPUsers)) {
                    File.Create(FPUsers);
                    //TODO: aggiunta di un segretario
                }
            }
        }

        public static string FPTasks {
            get => _FPTasks;
            private set {
                if (!DataChecker.IsValidString(value, CheckStr.Generic))
                    throw new Exception("Inserire un percorso file per il file 'tasks.json' valido");

                _FPTasks = value;

                if (!File.Exists(FPTasks)) {
                    File.Create(FPTasks);
                }
            }
        }

        public static string FPDistricts {
            get => _FPDistricts;
            private set {
                if (!DataChecker.IsValidString(value, CheckStr.Generic))
                    throw new Exception("Inserire un percorso file per il file 'districts.json' valido");

                _FPDistricts = value;

                if (!File.Exists(FPDistricts)) {
                    List<string> defaultDistricts = new List<string> { "CENTRO", "CAPPUCCINI", "INDUSTRIALE"};
                    File.Create(FPDistricts);
                    //TODO: JsonClass.Write();
                }
            }
        }

        public static string FPJobs {
            get => _FPJobs;
            private set {
                if (!DataChecker.IsValidString(value, CheckStr.Generic))
                    throw new Exception("Inserire un percorso file per il file 'jobs.json' valido");

                _FPJobs = value;

                if (!File.Exists(FPJobs)) {
                    List<string> defaultJobs = new List<string> { "SEGRETERIA", "IDRAULICA", "MECCANICA", "BADANTE" };
                    File.Create(FPJobs);
                    //TODO: JsonClass.Write();
                }
            }
        }
        public static float DeltaPercentage {
            get => _deltaPercentage;
            private set => DataChecker.SetIfValidNumber(ref _deltaPercentage, value, "Inserire una percentuale [0-100]", CheckNumb.Percentage);
        }
    }
}
