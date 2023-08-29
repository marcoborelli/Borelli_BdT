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
        private MainPage.TaskType TaskType { get; set; }
        private MainPage.LoadTskList LoadList { get; set; }
        public MainPagePresenter(MainPage view, string username) {
            View = view;
            CurrentUser = UsersList.GetUser(username);

            if (CurrentUser == null)
                throw new Exception("Inserire un utente valido");

            LoadSelectedTab();
        }

        private MainPage View {
            get => _view;
            set => _view = (value != null) ? value : throw new Exception("Inserire un attributo view valido");
        }

        public void SelectedTabChanged(object sender, EventArgs e) {
            LoadSelectedTab();
        }

        public void LoadSelectedTab() {
            int tabIndex = View.GetSelectedTabIndex();

            switch (tabIndex) {
                case 0:
                    LoadList = MainPage.LoadTskList.HomeScreen;
                    View.Text = "Home page";

                    LoadHomeScreen();
                    break;
                case 1:
                    TaskType = MainPage.TaskType.Pertinent;
                    LoadList = MainPage.LoadTskList.Details;
                    View.Text = "Richiesta-Accettazione task";

                    LoadReqAcceptTask();
                    LoadJobsList();
                    break;
                case 2:
                    TaskType = MainPage.TaskType.Accepted;
                    LoadList = MainPage.LoadTskList.Details;
                    View.Text = "Task accettate";

                    View.LoadLegendPaletteAcceptedTask();
                    LoadAcceptedTasks();
                    break;
                case 3:
                    TaskType = MainPage.TaskType.Requested;
                    LoadList = MainPage.LoadTskList.Details;
                    View.Text = "Tab richieste";

                    View.LoadLegendPaletteRequestedTask();
                    LoadRequestedTasks();
                    break;
                case 4:
                    View.Text = "Accettazione nuovi utenti";
                    LoadAcceptNewUserTab();
                    break;
            }
        }



        public void LoadHomeScreen() {
            View.LoadUserData(EntityCustomerMasterData.GetEntity(CurrentUser.Data), $"{Parameters.DPPictures}/{CurrentUser.Nickname}.jpg");

            List<EntityTask> pertinentTasks = GetEntityTasksList(TasksList.GetAppropriateTasks(CurrentUser, TaskUserFilter.ZoneAndJob));
            View.LoadTasksList(pertinentTasks, MainPage.TaskType.Pertinent, LoadList);

            List<EntityTask> doneTasks = GetEntityTasksList(TasksList.GetAcceptedTasks(CurrentUser.Nickname, AcTaskState.Done));
            View.LoadTasksList(doneTasks, MainPage.TaskType.Accepted, LoadList);

            View.WriteDeltaHours(CurrentUser.DoneHours - CurrentUser.RecievedHours);

            List<EntityTask> reqTask = GetEntityTasksList(TasksList.GetRequestedTasks(CurrentUser.Nickname, RqTaskState.Done));
            View.LoadTasksList(reqTask, MainPage.TaskType.Requested, LoadList);
        }

        public void DoubleClickLWRequestedTask(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromListView(MainPage.TaskType.Requested, LoadList);
            EntityUser eu = EntityUser.GetEntity(CurrentUser);

            View.OpenTaskDetailsForm(taskId, eu);
        }

        public void DoubleClickLWPertinentTask(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromListView(MainPage.TaskType.Pertinent, LoadList);
            EntityUser eu = EntityUser.GetEntity(CurrentUser);

            View.OpenTaskDetailsForm(taskId, eu);
        }

        public void DoubleClickLWAcceptedTask(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromListView(MainPage.TaskType.Accepted, LoadList);
            EntityUser eu = EntityUser.GetEntity(CurrentUser);

            View.OpenTaskDetailsForm(taskId, eu);
        }



        public void LoadReqAcceptTask() {
            Regex rxRicerca = new Regex(View.GetTextInSearchBar(TaskType), RegexOptions.IgnoreCase);

            List<EntityTask> pertinentTasks = GetEntityTasksList(TasksList.GetAppropriateTasks(CurrentUser, TaskUserFilter.ZoneAndJob));
            List<EntityTask> pertinentFilteredTask = FilterTasks(pertinentTasks, rxRicerca, View.GetUsedFilter(TaskType));

            View.ClearListViewTask(TaskType, LoadList);
            View.LoadTasksList(pertinentFilteredTask, TaskType, LoadList);
        }

        public void LoadJobsList() {
            View.LoadJobsList(Jobs.Works);
        }

        public void ReLoadReqAcceptTask(object sender, EventArgs e) {
            LoadReqAcceptTask();
        }

        public void OnAcceptTask(object sender, EventArgs e) {
            string id = View.GetTaskIdFromListView(TaskType, LoadList);
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
            AcTaskState taskState = View.GetUsedStateFilterInAccepted();

            Regex rxRicerca = new Regex(View.GetTextInSearchBar(TaskType), RegexOptions.IgnoreCase);

            List<EntityTask> doneTasks = GetEntityTasksList(TasksList.GetAcceptedTasks(CurrentUser.Nickname, taskState));
            List<EntityTask> doneFilteredTasks = FilterTasks(doneTasks, rxRicerca, View.GetUsedFilter(TaskType));

            View.ClearListViewTask(TaskType, LoadList);
            View.LoadTasksList(doneFilteredTasks, TaskType, LoadList);
        }

        public void ReLoadAcceptedTasks(object sender, EventArgs e) {
            LoadAcceptedTasks();
        }

        public bool IsTaskDone(EntityTask e) {
            Task t = EntityTask.GetTask(e);

            return t.Status == TPhase.Done;
        }



        public void LoadRequestedTasks() {
            RqTaskState taskState = View.GetUsedStateFilterInRequested();

            Regex rxRicerca = new Regex(View.GetTextInSearchBar(TaskType), RegexOptions.IgnoreCase);

            List<EntityTask> requestedTasks = GetEntityTasksList(TasksList.GetRequestedTasks(CurrentUser.Nickname, taskState));
            List<EntityTask> requestedPertinentTasks = FilterTasks(requestedTasks, rxRicerca, View.GetUsedFilter(TaskType));

            View.ClearListViewTask(TaskType, LoadList);
            View.LoadTasksList(requestedPertinentTasks, TaskType, LoadList);
        }

        public void ReLoadRequestedTasks(object sender, EventArgs e) {
            LoadRequestedTasks();
        }

        public bool IsTaskAccepted(EntityTask e) {
            Task t = EntityTask.GetTask(e);

            return t.Status == TPhase.Accepted;
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



        public bool IsSecretary() {
            return (CurrentUser.Level == UserLevel.Secretary);
        }

        public void DoubleClickDetailsLW(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromListView(TaskType, LoadList);
            EntityUser eu = EntityUser.GetEntity(CurrentUser);

            View.OpenTaskDetailsForm(taskId, eu);
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

        private List<EntityTask> FilterTasks(List<EntityTask> input, Regex rx, MainPage.ResearchOption opt) {
            List<EntityTask> outp = new List<EntityTask>();

            for (int i = 0; i < input.Count; i++) {
                switch (opt) {
                    case MainPage.ResearchOption.Acceptor:
                        if (input[i].Field4 == null && rx.ToString() == String.Empty) { //per la listView delle task richieste che non per forza sono ancora state accettate
                            outp.Add(input[i]);
                        } else if (input[i].Field4 != null && rx.IsMatch(input[i].Field4)) {
                            outp.Add(input[i]);
                        }
                        break;
                    case MainPage.ResearchOption.Requester:
                        if (rx.IsMatch(input[i].Field3))
                            outp.Add(input[i]);
                        break;
                    case MainPage.ResearchOption.Job:
                        if (rx.IsMatch(input[i].Field11))
                            outp.Add(input[i]);
                        break;
                    case MainPage.ResearchOption.None:
                        outp.Add(input[i]);
                        break;
                }
            }

            return outp;
        }
    }
}
