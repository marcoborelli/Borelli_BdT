using Borelli_BdT.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_BdT.presenter {
    public class EntityTask {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public string Field11 { get; set; }

        public static EntityTask GetEntity(model.Task t) {
            if (t == null)
                throw new Exception("Inserire una task valida");

            EntityTask e = new EntityTask {
                Field1 = t.Id,
                Field2 = t.RequesterNickname,
                Field3 = t.AcceptorNickname,
                Field4 = $"{t.RequestDate}",
                Field5 = $"{t.AcceptedTaskDate}",
                Field6 = $"{t.StartTaskDate}",
                Field7 = $"{t.EndTaskDate}",
                Field8 = $"{t.TaskLength}",
                Field9 = $"{t.Stars}",
                Field10 = t.Job,
                Field11 = nameof(t.Status)
            };

            return e;
        }

        public static model.Task GetTask(EntityTask e) {
            return new model.Task(e.Field1, e.Field2, e.Field3, DateTime.Parse(e.Field4), DateTime.Parse(e.Field5), DateTime.Parse(e.Field6),
                DateTime.Parse(e.Field7),TimeSpan.Parse(e.Field8), float.Parse(e.Field9), e.Field10, (TPhase)Enum.Parse(typeof(TPhase), e.Field11));
        }

        public static string[] GetEntityFieldNames() {
            return new string[] { "ID", "RICHIEDENTE", "ACCETTANTE", "DATA-RICHIESTA", "DATA-ACCETTATA", "DATA-INZIO", "DATA-FINE", "DURATA", "STELLE", "LAVORO", "STATO" };
        }
    }
}
