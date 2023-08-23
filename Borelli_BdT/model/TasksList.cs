using System;
using System.Collections.Generic;
using System.Linq;
using Borelli_BdT.utilities;

namespace Borelli_BdT.model {
    public static class TasksList {
        public static List<Task> Tasks { get; private set; }

        public static void Init() {
            FileManager.CheckTasksFile();
            Tasks = new List<Task>(FileManager.ReadJsonFile<List<Task>>(Parameters.FPTasks));
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

        public static void AddTask(Task t) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            if (t == null)
                throw new Exception("Inserire una task valida");

            Tasks.Add(t);
        }

        public static void RemoveTask(Task t) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            if (t == null)
                throw new Exception("Inserire una task valida");

            Tasks.Remove(t);
        }

        public static void RemoveTask(string id) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            Task t = GetTask(id);
            RemoveTask(t);
        }

        public static List<Task> GetAppropriateTasks(User u, TaskUserFilter filter) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            if (!UsersList.IsUserValid(u))
                throw new Exception("Inserire un utente valido");


            List<Task> outp = new List<Task>();

            for (int i = 0; i < Tasks.Count; i++) {
                if (DataChecker.IsAppropriateTaskUser(Tasks[i], u, filter)) {
                    outp.Add(Tasks[i]);
                }
            }

            return outp;
        }

        public static List<Task> GetAppropriateTasks(string nickname, TaskUserFilter filter) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            User u = UsersList.GetUser(nickname);
            if (u == null) {
                throw new Exception("Inserire un utente valido");
            }

            return GetAppropriateTasks(u, filter);
        }


        public static List<Task> GetRequestedTasks(string username, RqTaskState whatState) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            if (!DataChecker.IsValidString(username, CheckStr.Nickname))
                throw new Exception("Inserire uno username associato ad un utente valido");

            List<Task> outp = new List<Task>();

            for (int i = 0; i < Tasks.Count; i++) {
                if (Tasks[i].RequesterNickname != username)
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


        public static List<Task> GetAcceptedTasks(string username, AcTaskState whatState) {
            if (Tasks == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica TasksList");

            if (!DataChecker.IsValidString(username, CheckStr.Nickname))
                throw new Exception("Inserire uno username associato ad un utente valido");

            List<Task> outp = new List<Task>();

            for (int i = 0; i < Tasks.Count; i++) {
                if (Tasks[i].AcceptorNickname != username) //se non e' quello colui che ha accettato salto anche lo switch
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
            FileManager.WriteJsonFile(Tasks, Parameters.FPTasks);
        }
    }
}
