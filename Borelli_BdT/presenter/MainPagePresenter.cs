using System;
using System.Windows.Forms;
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

        public void LoadSelectedTab(object sender, EventArgs e) {
            int tabIndex = View.GetSelectedTabIndex();

            switch (tabIndex) {
                case 0:
                    ChargeHomeScreen();
                    break;
                case 1:
                    LoadAcceptNewUserTab();
                    break;
            }
        }

        public void ChargeHomeScreen() {
            MainPage.LoadTskList tab = MainPage.LoadTskList.HomeScreen;

            View.ChargeUserData(EntityCustomerMasterData.GetEntity(CurrentUser.Data), $"{Parameters.DPPictures}/{CurrentUser.Nickname}.jpg");

            List<EntityTask> pertinentTasks = GetEntityTasksList(TasksList.GetAppropriateTasks(CurrentUser, TaskUserFilter.ZoneAndJob));
            View.LoadTasksList(pertinentTasks, MainPage.TaskType.Pertinent, tab);

            List<EntityTask> doneTasks = GetEntityTasksList(TasksList.GetAcceptedTasks(CurrentUser.Nickname, AcTaskState.Done));
            View.LoadTasksList(doneTasks, MainPage.TaskType.Done, tab);

            View.WriteDeltaHours(CurrentUser.DoneHours - CurrentUser.RecievedHours);

            List<EntityTask> reqTask = GetEntityTasksList(TasksList.GetRequestedTasks(CurrentUser.Nickname, RqTaskState.Done));
            View.LoadTasksList(reqTask, MainPage.TaskType.Requested, tab);
        }



        public void DoubleClickOnAcceptUsersLW(object sender, MouseEventArgs e) {
            string uNick = View.GetUserNicknameInUsersListView();

            User u = UsersList.GetUser(uNick);
            EntityUser eu = EntityUser.GetEntity(u);

            View.OpenSignUpForm(eu);
        }
        public void LoadAcceptNewUserTab() {
            List<EntityUser> stillNotAcceptedUsers = GetEntityUsersList(UsersList.GetInPhaseUsers(RegContext.Registration));
            View.LoadUsersList(stillNotAcceptedUsers, MainPage.LoadUsrList.ToAccept);
        }

        public void OnModifyDistr(object sender, EventArgs e) {
            View.ShowEditorForm(ItemsEditor.Use.Districts);
        }
        public void OnModifyJobs(object sender, EventArgs e) {
            View.ShowEditorForm(ItemsEditor.Use.Jobs);
        }





        private List<EntityTask> GetEntityTasksList(List<model.Task> input) {
            List<EntityTask> outp = new List<EntityTask>();

            for (int i = 0; i < input.Count; i++) {
                outp.Add(EntityTask.GetEntity(input[i]));
            }

            return outp;
        }

        private List<EntityUser> GetEntityUsersList(List<User> input) {
            List<EntityUser> outp = new List<EntityUser>();

            for (int i = 0; i < input.Count; i++) {
                outp.Add(EntityUser.GetEntity(input[i]));
            }

            return outp;
        }
    }
}
