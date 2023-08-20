using System;
using Borelli_BdT.utilities;
using Newtonsoft.Json;

namespace Borelli_BdT.model {
    public enum TPhase {
        Nothing,
        Request,
        Accepted,
        Done
    }
    public class Task : IEquatable<Task> {
        private string _requesterNickname, _acceptorNickname;

        [JsonProperty]
        public TPhase Status { get; private set; }

        [JsonProperty]
        public DateTime RequestDate { get; private set; }
        private DateTime _acceptedTaskDate, _startTaskDate, _endTaskDate;
        private TimeSpan _taskLength;
        private float _stars;
        private string _job, _id;

        [JsonProperty]
        public string Id {
            get => _id;
            private set => DataChecker.SetIfValidString(ref _id, value, "Errore durante l'assegnazione dell'id", CheckStr.Generic);
        }

        [JsonProperty]
        public string Job {
            get => _job;
            private set => DataChecker.SetIfValidString(ref _job, value, "Inserire un tipo di lavoro valido", CheckStr.Work);
        }

        [JsonProperty]
        public string RequesterNickname {
            get => _requesterNickname;
            private set => DataChecker.SetIfValidString(ref _requesterNickname, value, "Inserire un nickname di un richiedente associato ad un utente", CheckStr.Nickname);
        }
        [JsonProperty]
        public string AcceptorNickname {
            get => _acceptorNickname;
            private set {
                if ((int)Status >= (int)TPhase.Accepted) {
                    if (value != RequesterNickname) {
                        DataChecker.SetIfValidString(ref _acceptorNickname, value, "Inserire un nickname di un accettatore associato ad un utente", CheckStr.Nickname);
                    } else {
                        throw new Exception("Il richiedente non può essere uguale a colui che accetta");
                    }
                }
            }
        }

        [JsonProperty]
        public DateTime AcceptedTaskDate {
            get => _acceptedTaskDate;
            private set {
                if ((int)Status >= (int)TPhase.Accepted) {
                    _acceptedTaskDate = value;
                }
            }
        }

        [JsonProperty]
        public DateTime StartTaskDate {
            get => _startTaskDate;
            private set {
                if ((int)Status >= (int)TPhase.Accepted) {
                    _startTaskDate = value;
                }
            }
        }

        [JsonProperty]
        public DateTime EndTaskDate {
            get => _endTaskDate;
            private set {
                if ((int)Status >= (int)TPhase.Done) {
                    if (!(value.Date < StartTaskDate)) {
                        _endTaskDate = value;
                    } else {
                        throw new Exception($"Inserire una data valida di terminazione del lavoro");
                    }
                }
            }
        }

        [JsonProperty]
        public TimeSpan TaskLength {
            get => _taskLength;
            private set {
                if ((int)Status >= (int)TPhase.Done) {
                    if (value.TotalHours < (EndTaskDate - StartTaskDate).TotalHours) {
                        _taskLength = value;
                    } else {
                        throw new Exception($"Inserire una durata valida del lavoro");
                    }
                }
            }
        }

        [JsonProperty]
        public float Stars {
            get => _stars;
            private set {
                if ((int)Status >= (int)TPhase.Done) {
                    DataChecker.SetIfValidNumber(ref _stars, value, "Inserire un corretto numero di stelle [0-5]", CheckNumb.Stars);
                }
            }
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


        public bool Equals(Task t) {
            if (t == null) {
                return false;
            } else if (t == this) {
                return true;
            } else {
                return (t.Id == Id);
            }
        }
    }
}
