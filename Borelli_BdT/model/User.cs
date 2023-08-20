using System;
using System.Collections.Generic;
using Borelli_BdT.utilities;
using Newtonsoft.Json;

namespace Borelli_BdT.model {
    public enum RegContext {
        Registration,
        Confirmed
    }

    public class User : IEquatable<User> {
        private string _nickname, _password;
        private CustomerMasterData _data;
        private List<string> _providesJobs;
        private List<string> _jobsDistrict;
        private float _totalStars, _averageStars, _doneJobsNumber;

        [JsonProperty]
        public TimeSpan DoneHours { get; private set; }

        [JsonProperty]
        public TimeSpan RecievedHours { get; private set; }

        [JsonProperty]
        public RegContext State { get; private set; }


        public User() {
        }

        public User(CustomerMasterData userData, string nickname, string passwd, List<string> providesJobs, List<string> jobDistr,
            float totalStar, float averageStar, float doneJobsNumber, TimeSpan doneHours, TimeSpan recievedHours, RegContext step) {

            State = step;

            Data = userData;

            Nickname = nickname;
            Password = passwd;

            ProvidesJobs = new List<string>(providesJobs);
            JobsDistrict = new List<string>(jobDistr);

            TotalStars = totalStar;
            AverageStars = averageStar;
            DoneJobsNumber = doneJobsNumber;

            DoneHours = doneHours;
            RecievedHours = recievedHours;
        }
        public User(CustomerMasterData userData, string nickname, string passwd, List<string> providesJobs, List<string> jobDistr, RegContext step) :
            this(userData, nickname, passwd, providesJobs, jobDistr, 0, 0, 0, new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), step) {
        }


        public User(string name, string surnm, string phoneNum, string mail, string homeAddress, string distr, DateTime birthDate, string nicknm,
            string passwd, List<string> providesJobs, List<string> jobDistr, float totalStar, float averageStar, float doneJobsNumber,
            TimeSpan doneHours, TimeSpan recievedHours, RegContext step) : this
            (new CustomerMasterData(name, surnm, phoneNum, mail, homeAddress, distr, birthDate), nicknm, passwd, providesJobs, jobDistr,
            totalStar, averageStar, doneJobsNumber, doneHours, recievedHours, step) {
        }

        public User(string name, string surnm, string phoneNum, string mail, string homeAddress, string distr, DateTime birthDate, string nicknm,
            string passwd, List<string> providesJobs, List<string> jobDistr, RegContext step) : this
            (new CustomerMasterData(name, surnm, phoneNum, mail, homeAddress, distr, birthDate), nicknm, passwd, providesJobs, jobDistr, step) {
            //sto solo ricreando l'oggetto prendendo in input tutti i campi
        }


        [JsonProperty]
        public string Nickname { //PK
            get => _nickname;
            private set => DataChecker.SetIfValidString(ref _nickname, value, "Inserire un nickname valido", CheckStr.Generic);
        }
        [JsonProperty]
        public string Password { //TODO: se si puo' rimettere, tutto privato
            get => _password;
            private  set => DataChecker.SetIfValidString(ref _password, value, "Inserire una password valida", CheckStr.Generic);
        }
        [JsonProperty]
        public List<string> ProvidesJobs {
            get => _providesJobs;
            private set {
                switch (State) {
                    case RegContext.Registration:
                        DataChecker.SetIfListStrValid(ref _providesJobs, value, "Inserire una lista di lavori validi", CheckStrList.Generic);
                        break;
                    case RegContext.Confirmed:
                        DataChecker.SetIfListStrValid(ref _providesJobs, value, "Uno o più elementi della lista non sono riconosciuti come lavori", CheckStrList.Work);
                        break;
                }
            }
        }
        [JsonProperty]
        public List<string> JobsDistrict {
            get => _jobsDistrict;
            private set => DataChecker.SetIfListStrValid(ref _jobsDistrict, value, "Uno o più elementi della lista non sono riconosciuti come zone di lavoro", CheckStrList.District);
        }
        [JsonProperty]
        public float TotalStars {
            get => _totalStars;
            private set => DataChecker.SetIfValidNumber(ref _totalStars, value, "La somma totale delle stelle deve essere positiva", CheckNumb.Positive);
        }
        [JsonProperty]
        public float AverageStars {
            get => _averageStars;
            private set => DataChecker.SetIfValidNumber(ref _averageStars, value, "Inserire un corretto numero di stelle [0-5]", CheckNumb.Stars);
        }
        [JsonProperty]
        public float DoneJobsNumber {
            get => _doneJobsNumber;
            private set => DataChecker.SetIfValidNumber(ref _doneJobsNumber, value, "La somma totale del numero di lavori fatti deve essere positiva", CheckNumb.Positive);
        }
        [JsonProperty]
        public CustomerMasterData Data {
            get => _data;
            private set {
                if (value != null) {
                    _data = value;
                } else {
                    throw new Exception("Inserire dei dati anagrafici dell'utente validi");
                }
            }
        }



        public Task RequestTask(string job) {
            Task t = new Task();
            int oreChePuoSforare = (DoneHours.Hours * 12) / 100; //puo' sforare del 12% delle ore donate

            if ((DoneHours - RecievedHours) < new TimeSpan(-oreChePuoSforare + 1, 0, 0)) //+1 perche' se si e' alla prima richiesta lo si concede
                throw new Exception("Sono state sforate le ore massime di differenza tra ore donate/ricevute");

            t.Create(Nickname, DateTime.Now, job);

            return t;
        }

        public void AcceptTask(Task t) { //ad accettare il task non è lo stesso oggetto utente che l'ha richiesta
            if (t == null || t.Status != TPhase.Request)
                throw new Exception("Inserire una task valida da accettare");

            t.Accept(Nickname, DateTime.Now);
        }


        public void EndRequestedTask(Task t, User acceptedUser, DateTime startTask, DateTime endTask, TimeSpan taskLength, float stars) {
            if (t == null || t.Status != TPhase.Accepted || t.RequesterNickname != Nickname)
                throw new Exception("Inserire una task valida in uno stato valido");

            if (acceptedUser == null || acceptedUser.Nickname != t.AcceptorNickname)
                throw new Exception("Inserire il giusto utente che ha accettato la task");

            t.End(startTask, endTask, taskLength, stars);

            AddRecievedHours(taskLength);
            acceptedUser.AddHoursAndStarsToUser(taskLength, stars);
        }

        public void AddDoneHours(TimeSpan t) {
            if (t < new TimeSpan(0, 0, 0))
                throw new Exception("Inserire un aumento positivo di ore");

            DoneHours += t;
        }
        public void AddRecievedHours(TimeSpan t) {
            if (t < new TimeSpan(0, 0, 0))
                throw new Exception("Inserire una diminuzione positiva di ore");

            RecievedHours += t;
        }

        public bool IsPasswordCorrect(string passwd) {
            return (passwd == Password);
        }

        private void AddHoursAndStarsToUser(TimeSpan taskLength, float star) {
            AddDoneHours(taskLength);

            DoneJobsNumber++;
            TotalStars += star;

            //per arrotondare ogni 0.25
            AverageStars = (float)(Math.Round((TotalStars / DoneJobsNumber) * 4, MidpointRounding.ToEven)) / 4;
        }

        public bool Equals(User u) {
            if (u == null) {
                return false;
            } else if (u == this) {
                return true;
            } else {
                return (u.Nickname == Nickname);
            }
        }
    }
}
