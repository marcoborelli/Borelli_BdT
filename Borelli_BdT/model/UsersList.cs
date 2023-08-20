﻿using System;
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

        public static List<User> GetInPhaseUsers(RegContext phase) {
            if (Users == null)
                throw new Exception("Lista non inizializzata, chiamare prima l'initializer della classe statica UsersList");

            List<User> outp = new List<User>();

            for (int i = 0; i < Users.Count; i++) {
                if (Users[i].State == phase)
                    outp.Add(Users[i]);
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
