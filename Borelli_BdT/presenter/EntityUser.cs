using System;
using System.Collections.Generic;
using Borelli_BdT.model;

namespace Borelli_BdT.presenter {
    public class EntityUser {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public List<string> Field3 { get; set; }
        public List<string> Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public string Field11 { get; set; }
        public EntityCustomerMasterData Field12 { get; set; }

        public EntityUser() {
            Field3 = new List<string>();
            Field4 = new List<string>();
        }

        public static EntityUser GetEntity(User u) {
            if (u == null)
                throw new Exception("Inserire un utente valido");

            EntityUser e = new EntityUser {
                Field1 = u.Nickname,
                Field2 = u.Password,
                Field3 = u.ProvidesJobs,
                Field4 = u.JobsDistrict,
                Field5 = $"{u.TotalStars}",
                Field6 = $"{u.AverageStars}",
                Field7 = $"{u.DoneJobsNumber}",
                Field8 = $"{u.DoneHours}",
                Field9 = $"{u.RecievedHours}",
                Field10 = u.State.ToString(),
                Field11 = u.Level.ToString(),
                Field12 = EntityCustomerMasterData.GetEntity(u.Data),
            };

            return e;
        }

        public static List<EntityUser> GetEntityUsersList(List<User> input) {
            List<EntityUser> outp = new List<EntityUser>();

            for (int i = 0; i < input.Count; i++) {
                outp.Add(EntityUser.GetEntity(input[i]));
            }

            return outp;
        }

        public static User GetUser(EntityUser e) {
            CustomerMasterData data = EntityCustomerMasterData.GetCustomerMasterData(e.Field12);

            return new User(data, e.Field1, e.Field2, e.Field3, e.Field4, float.Parse(e.Field5), float.Parse(e.Field6), float.Parse(e.Field7),
                TimeSpan.Parse(e.Field8), TimeSpan.Parse(e.Field9), (RegContext)Enum.Parse(typeof(RegContext), e.Field10), (UserLevel)Enum.Parse(typeof(UserLevel), e.Field11));
        }


        public static string[] GetEntityFieldNames() {
            return new string[] { "NICKNAME", "PASSWD", "LAV. OFFERT", "QUARTIERI LAVORI", "STELLE TOT", "MEDIA STELLE",
                "NUM. LAVORI FATTI", "ORE FATTE", "ORE RICEVUTE", "STATO", "LIVELLO", "DATI ANAGRAFICI" };
        }
    }
}
