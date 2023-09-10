using System;
using System.Collections.Generic;
using System.Linq;
using Borelli_BdT.utilities;

namespace Borelli_BdT.model {
    public static class UsersList {
        public static List<User> Users { get; private set; }

        public static void Init() {
            FileManager.CheckUsersFile();
            Users = new List<User>(FileManager.ReadJsonFile<List<User>>(Parameters.FPUsers));
        }

        public static int GetUserIndex(string username) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            return Users.FindIndex(x => x.Nickname == username);
        }
        public static int GetUserIndex(User u) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            return Users.IndexOf(u);
        }
        public static User GetUser(string username) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            return Users.FirstOrDefault(x => x.Nickname == username);
        }


        public static bool IsUserValid(User u) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            return Users.Contains(u);
        }
        public static bool IsUserValid(string username) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            return (Users.FindIndex(x => x.Nickname == username) != -1);
        }

        public static void AddUser(User u) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            if (u == null)
                throw new Exception("Inserire un utente valido");

            Users.Add(u);
        }

        public static void RemoveUser(User u) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            if (u == null)
                throw new Exception("Inserire un utente valido");

            Users.Remove(u);
        }
        public static void RemoveUser(string username) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            User u = GetUser(username);
            Users.Remove(u);
        }

        public static List<User> GetInPhaseUsers(UsersState state) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            List<User> outp = new List<User>();

            for (int i = 0; i < Users.Count; i++) {
                switch (state) {
                    case UsersState.Registration:
                        if (Users[i].State == RegContext.Registration) {
                            outp.Add(Users[i]);
                        }
                        break;
                    case UsersState.Confirmed:
                        if (Users[i].State == RegContext.Confirmed) {
                            outp.Add(Users[i]);
                        }
                        break;
                    case UsersState.All:
                        outp.Add(Users[i]);
                        break;
                }
            }

            return outp;
        }

        public static List<User> GetUserBasedOnDeltaHours(UserDelta filter) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            List<User> outp = new List<User>();
            double delta;

            for (int i = 0; i < Users.Count; i++) {
                if (Users[i].State == RegContext.Registration)
                    continue;

                switch (filter) {
                    case UserDelta.Greater:
                        delta = (Users[i].DoneHours - Users[i].RecievedHours).TotalMinutes;
                        if (delta >= 0) {
                            outp.Add(Users[i]);
                        }
                        break;
                    case UserDelta.Less:
                        delta = (Users[i].DoneHours - Users[i].RecievedHours).TotalMinutes;
                        if (delta < 0) {
                            outp.Add(Users[i]);
                        }
                        break;
                    case UserDelta.All:
                        outp.Add(Users[i]);
                        break;
                }
            }

            return outp;
        }

        public static List<User> GetAppropriateUsers(Task t, TaskUserFilter filter) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            if (!TasksList.IsTaskValid(t))
                throw new Exception("Inserire una task valida");

            List<User> outp = new List<User>();

            for (int i = 0; i < Users.Count; i++) {
                if (DataChecker.IsAppropriateTaskUser(t, Users[i], filter)) {
                    outp.Add(Users[i]);
                }
            }

            return outp;
        }

        public static List<User> GetAppropriateUsers(string id, TaskUserFilter filter) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            Task t = TasksList.GetTask(id);
            if (t == null) {
                throw new Exception("Inserire una task valida");
            }

            return GetAppropriateUsers(t, filter);
        }

        public static void WriteJsonFile() {
            FileManager.WriteJsonFile(Users, Parameters.FPUsers);
        }
    }
}
