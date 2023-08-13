using System;
using Borelli_BdT.utilities;

namespace Borelli_BdT.model {
    public enum TPhase {
        Nothing,
        Request,
        Accepted,
        Done
    }
    public class Task {
        private string _requesterNickname, _acceptorNickname;

        public DateTime RequestDate { get; private set; }
        public DateTime AcceptedTaskDate { get; private set; }
        public DateTime StartTaskDate { get; private set; }
        private DateTime _endTaskDate;
        private TimeSpan _taskLength;
        public TPhase Status { get; private set; }
        private float _stars;
        private string _job, _id;

        public string RequesterNickname {
            get => _requesterNickname;
            private set => DataChecker.SetIfValidString(ref _requesterNickname, value, "Inserire un nickname di un richiedente associato ad un utente", CheckStr.Nickname);
        }
        public string AcceptorNickname {
            get => _acceptorNickname;
            private set {
                if (value != RequesterNickname) {
                    DataChecker.SetIfValidString(ref _acceptorNickname, value, "Inserire un nickname di un accettatore associato ad un utente", CheckStr.Nickname);
                } else {
                    throw new Exception("Il richiedente non può essere uguale a colui che accetta");
                }
            }
        }
        public DateTime EndTaskDate {
            get => _endTaskDate;
            private set {
                if (!(value.Date < StartTaskDate)) {
                    _endTaskDate = value;
                } else {
                    throw new Exception($"Inserire una data valida di terminazione del lavoro");
                }
            }
        }
        public TimeSpan TaskLength {
            get => _taskLength;
            private set {
                if (value.TotalHours < (EndTaskDate - StartTaskDate).TotalHours) {
                    _taskLength = value;
                } else {
                    throw new Exception($"Inserire una durata valida del lavoro");
                }
            }
        }
        public float Stars {
            get => _stars;
            private set => DataChecker.SetIfValidNumber(ref _stars, value, "Inserire un corretto numero di stelle [0-5]", CheckNumb.Stars);
        }
        public string Job {
            get => _job;
            private set => DataChecker.SetIfValidString(ref _job, value, "Inserire un tipo di lavoro valido", CheckStr.Work);
        }
        public string Id {
            get => _id;
            private set => DataChecker.SetIfValidString(ref _id, value, "Errore durante l'assegnazione dell'id", CheckStr.Generic);
        }


        public Task() {
            Status = TPhase.Nothing;
        }

        public void Create(string reqNickname, DateTime reqDate, string job) { //a farla e' il richiedente
            Status = TPhase.Request;
            Id = CreateId(reqNickname, reqDate);
            RequesterNickname = reqNickname;
            RequestDate = reqDate;
            Job = job;
        }

        public void Accept(string accUserNickname, DateTime startTaskDate) { //a farla e' il donatore di ore
            if (Status != TPhase.Request)
                throw new Exception("Non è stato rispettato il giusto procedimento nella macchina a stati della task");

            Status = TPhase.Accepted;
            AcceptorNickname = accUserNickname;
            AcceptedTaskDate = startTaskDate;
        }

        public void End(DateTime startTaskDate, DateTime endTaskDate, TimeSpan taskDuration, float starsValutation) { //a farlo e' il richiedente
            if (Status != TPhase.Accepted)
                throw new Exception("Non è stato rispettato il giusto procedimento nella macchina a stati della task");

            Status = TPhase.Done;

            StartTaskDate = startTaskDate;
            EndTaskDate = endTaskDate;
            TaskLength = taskDuration;

            Stars = starsValutation;
        }

        private string CreateId(string nickname, DateTime time) {
            string outp = "";
            Random rnd = new Random();

            for (int i = 0; i < 4 && i < nickname.Length; i++) {
                outp += nickname[i];
            }
            if (outp.Length != 4) {
                while (outp.Length != 4)
                    outp += "N";
            }

            for (int i = 0; i < 6; i++) {
                outp += rnd.Next(10);
            }

            return outp;
        }

    }
}
