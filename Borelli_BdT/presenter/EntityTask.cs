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
        public string Field12 { get; set; }

        public static EntityTask GetEntity(model.Task t) {
            if (t == null)
                throw new Exception("Inserire una task valida");

            EntityTask e = new EntityTask {
                Field1 = t.Id,
                Field2 = t.Caption,
                Field3 = t.RequesterNickname,
                Field4 = t.AcceptorNickname,
                Field5 = $"{t.RequestDate}",
                Field6 = $"{t.AcceptedTaskDate}",
                Field7 = $"{t.StartTaskDate}",
                Field8 = $"{t.EndTaskDate}",
                Field9 = $"{t.TaskLength}",
                Field10 = $"{t.Stars}",
                Field11 = t.Job,
                Field12 = nameof(t.Status)
            };

            return e;
        }

        public static model.Task GetTask(EntityTask e) {
            return new model.Task(e.Field1, e.Field2, e.Field3, e.Field4, DateTime.Parse(e.Field5), DateTime.Parse(e.Field6), DateTime.Parse(e.Field7),
                DateTime.Parse(e.Field8), TimeSpan.Parse(e.Field9), float.Parse(e.Field10), e.Field11, (TPhase)Enum.Parse(typeof(TPhase), e.Field12));
        }

        public static string[] GetEntityFieldNames() {
            return new string[] { "ID", "DESCRIZIONE", "RICHIEDENTE", "ACCETTANTE", "DATA-RICHIESTA", "DATA-ACCETTATA", "DATA-INZIO", "DATA-FINE", "DURATA", "STELLE", "LAVORO", "STATO" };
        }
    }
}
