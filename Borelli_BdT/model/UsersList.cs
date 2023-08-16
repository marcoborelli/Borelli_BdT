using System;
using System.Collections.Generic;
using System.Linq;
using Borelli_BdT.utilities;

namespace Borelli_BdT.model {
    public static class UsersList {
        public static List<User> Users { get; private set; }

        public static void Init() {
            FileManager.CheckUsersFile(Parameters.FPUsers);
            Users = new List<User>();
            Users = FileManager.ReadUsersFile(Parameters.FPUsers);
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


        public static void WriteJsonFile() {
            FileManager.WriteUsersFile(Users, Parameters.FPUsers);
        }
    }
}
