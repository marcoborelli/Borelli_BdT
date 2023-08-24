using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
                    LoadReqAcceptTask();
                    LoadJobsList();
                    break;
                case 2:
                    LoadAcceptedTasks();
                    break;
                case 3:
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



        public void LoadReqAcceptTask() {
            MainPage.TaskType tt = MainPage.TaskType.Pertinent;

            Regex rxRicerca = new Regex(View.GetTextInSearchBar(tt), RegexOptions.IgnoreCase);

            List<EntityTask> pertinentTasks = GetEntityTasksList(TasksList.GetAppropriateTasks(CurrentUser, TaskUserFilter.ZoneAndJob));
            List<EntityTask> pertinentFilteredTask = FilterTasks(pertinentTasks, rxRicerca, View.GetUsedFilter(tt));

            View.ClearListViewTask(tt, MainPage.LoadTskList.Details);
            View.LoadTasksList(pertinentFilteredTask, tt, MainPage.LoadTskList.Details);
        }

        public void LoadJobsList() {
            View.LoadJobsList(Jobs.Works);
        }

        public void ReLoadReqAcceptTask(object sender, EventArgs e) {
            LoadReqAcceptTask();
        }

        public void OnAcceptTask(object sender, EventArgs e) {
            MainPage.TaskType tt = MainPage.TaskType.Pertinent;

            string id = View.GetTaskIdFromListView(tt, MainPage.LoadTskList.Details);
            Task t = TasksList.GetTask(id);

            if (t == null)
                throw new Exception("Errore durante accettazione task");

            try {
                CurrentUser.AcceptTask(t);
                TasksList.WriteJsonFile();
            } catch (Exception ex) {
                View.ErrorInRequestAccept(ex.Message);
            }

            LoadReqAcceptTask();
        }

        public void OnRequestTask(object sender, EventArgs e) {
            List<string> param = View.GetReqestTaskFields();

            try {
                Task t = CurrentUser.RequestTask(param[0], param[1]);
                TasksList.AddTask(t);
                TasksList.WriteJsonFile();
            } catch (Exception ex) {
                View.ErrorInRequestAccept(ex.Message);
            }

            View.ResetRequestTaskFields();
        }



        public void LoadAcceptedTasks() {
            AcTaskState taskState = View.GetUsedStateFilter();
            MainPage.TaskType tt = MainPage.TaskType.Done;

            Regex rxRicerca = new Regex(View.GetTextInSearchBar(tt), RegexOptions.IgnoreCase);

            List<EntityTask> doneTasks = GetEntityTasksList(TasksList.GetAcceptedTasks(CurrentUser.Nickname, taskState));
            List<EntityTask> donePertinentTasks = FilterTasks(doneTasks, rxRicerca, View.GetUsedFilter(tt));

            View.LoadTasksList(donePertinentTasks, MainPage.TaskType.Done, MainPage.LoadTskList.Details);
        }

        public void ReLoadReqDoneTask(object sender, EventArgs e) {
            LoadAcceptedTasks();
        }

        public bool IsAcceptedTaskDone(EntityTask e) {
            Task t = EntityTask.GetTask(e);

            return t.Status == TPhase.Done;
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



        private List<EntityTask> FilterTasks(List<EntityTask> input, Regex rx, MainPage.ResarchOption opt) {
            List<EntityTask> outp = new List<EntityTask>();

            for (int i = 0; i < input.Count; i++) {
                switch (opt) {
                    case MainPage.ResarchOption.Acceptor:
                        if (rx.IsMatch(input[i].Field4))
                            outp.Add(input[i]);
                        break;
                    case MainPage.ResarchOption.Requester:
                        if (rx.IsMatch(input[i].Field3))
                            outp.Add(input[i]);
                        break;
                    case MainPage.ResarchOption.Job:
                        if (rx.IsMatch(input[i].Field11))
                            outp.Add(input[i]);
                        break;
                    case MainPage.ResarchOption.None:
                        outp.Add(input[i]);
                        break;
                }
            }

            return outp;
        }
    }
}
