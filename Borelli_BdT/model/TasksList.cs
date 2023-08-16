using System;
using System.Collections.Generic;
using System.Linq;
using Borelli_BdT.utilities;

namespace Borelli_BdT.model {
    public enum RqTaskState {
        Requested,
        Accepted,
        Done,
        All,
    }
    public enum AcTaskState {
        Accepted,
        Done,
        All,
    }
    public class TasksList {
        public static List<Task> Tasks { get; private set; }

        public static void Init() {
            FileManager.CheckTasksFile(Parameters.FPTasks);
            Tasks = new List<Task>();
            Tasks = FileManager.ReadTasksFile(Parameters.FPTasks);
        }

        public static int GetTaskIndex(string id) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            return Tasks.FindIndex(x => x.Id == id);
        }
        public static int GetTaskIndex(Task t) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            return Tasks.IndexOf(t);
        }
        public static Task GetTask(string id) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            return Tasks.FirstOrDefault(x => x.Id == id);
        }

        public static bool IsTaskValid(Task t) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            return Tasks.Contains(t);
        }
        public static bool IsTaskValid(string id) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            return (Tasks.FindIndex(x => x.Id == id) != -1);
        }

        public List<Task> GetRequestedTasks(string username, RqTaskState whatState) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            if (!DataChecker.IsValidString(username, CheckStr.Nickname))
                throw new Exception("Inserire uno username associato ad un utente valido");

            List<Task> outp = new List<Task>();

            for (int i = 0; i < Tasks.Count; i++) {
                if (Tasks[i].AcceptorNickname != username)
                    continue;

                switch (whatState) {
                    case RqTaskState.Requested:
                        if (Tasks[i].Status == TPhase.Request) {
                            outp.Add(Tasks[i]);
                        }
                        break;
                    case RqTaskState.Accepted:
                        if (Tasks[i].Status == TPhase.Accepted) {
                            outp.Add(Tasks[i]);
                        }
                        break;
                    case RqTaskState.Done:
                        if (Tasks[i].Status == TPhase.Done) {
                            outp.Add(Tasks[i]);
                        }
                        break;
                    case RqTaskState.All:
                        outp.Add(Tasks[i]);
                        break;
                }
            }

            return outp;
        }


        public List<Task> GetAcceptedTasks(string username, AcTaskState whatState) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            if (!DataChecker.IsValidString(username, CheckStr.Nickname))
                throw new Exception("Inserire uno username associato ad un utente valido");

            List<Task> outp = new List<Task>();

            for (int i = 0; i < Tasks.Count; i++) {
                if (Tasks[i].RequesterNickname != username) //se non è quello il richiedente salto anche lo switch
                    continue;

                switch (whatState) {
                    case AcTaskState.Accepted:
                        if (Tasks[i].Status == TPhase.Accepted) {
                            outp.Add(Tasks[i]);
                        }
                        break;
                    case AcTaskState.Done:
                        if (Tasks[i].Status == TPhase.Done) {
                            outp.Add(Tasks[i]);
                        }
                        break;
                    case AcTaskState.All:
                        outp.Add(Tasks[i]);
                        break;
                }
            }

            return outp;
        }

        public static void WriteJsonFile() {
            FileManager.WriteTasksFile(Tasks, Parameters.FPTasks);
        }
    }
}
