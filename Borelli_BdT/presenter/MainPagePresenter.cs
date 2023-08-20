using System;
using System.Collections.Generic;
using Borelli_BdT.model;
using Borelli_BdT.view;
using Borelli_BdT.utilities;

namespace Borelli_BdT.presenter {
    public class MainPagePresenter {
        private MainPage _view;
        private User CurrentUser { get; set; }
        public MainPagePresenter(MainPage view, string username) {
            View = view;
            CurrentUser = UsersList.GetUser(username);

            if (CurrentUser == null)
                throw new Exception("Inserire un utente valido");

            ChargeHomeScreen();
        }

        private MainPage View {
            get => _view;
            set => _view = (value != null) ? value : throw new Exception("Inserire un attributo view valido");
        }

        public void ChargeHomeScreen() {
            View.ChargeUserData(EntityCustomerMasterData.GetEntity(CurrentUser.Data), $"{Parameters.DPPictures}/{CurrentUser.Nickname}.jpg");

            List<EntityTask> pertinentTasks = GetEntityTasksList(TasksList.GetAppropriateTasks(CurrentUser, TaskUserFilter.ZoneAndJob));
            View.ChargeAppropriateTasks(pertinentTasks);

            List<EntityTask> doneTasks = GetEntityTasksList(TasksList.GetAcceptedTasks(CurrentUser.Nickname, AcTaskState.Done));
            View.ChargeDoneTasks(doneTasks);

            View.WriteDeltaHours(CurrentUser.DoneHours - CurrentUser.RecievedHours);

            List<EntityTask> reqTask = GetEntityTasksList(TasksList.GetRequestedTasks(CurrentUser.Nickname, RqTaskState.Done));
            View.ChargeRequestedTasks(reqTask);
        }

        public List<EntityTask> GetEntityTasksList(List<model.Task> input) {
            List<EntityTask> outp = new List<EntityTask>();

            for (int i = 0; i < input.Count; i++) {
                outp.Add(EntityTask.GetEntity(input[i]));
            }

            return outp;
        }
    }
}
