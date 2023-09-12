using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
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

        private bool FirstTimeInUsersTab { get; set; }


        public MainPagePresenter(MainPage view, string username) {
            View = view;
            CurrentUser = UsersList.GetUser(username);

            if (CurrentUser == null)
                throw new Exception("Inserire un utente valido");

            FirstTimeInUsersTab = true;

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
                    View.Text = "Task richieste";

                    View.LoadLegendPaletteRequestedTask();
                    LoadRequestedTasks();
                    break;
                case 4:
                    View.Text = "Lista utenti";

                    View.LoadLegendPaletteUsers();

                    if (FirstTimeInUsersTab) {
                        View.LoadJobsListInUsersTab(Jobs.Works, MainPage.ViewType.Users);
                        View.SetCheckedInJobsList(true, MainPage.ViewType.Users);
                    }

                    LoadUsersTab();
                    break;
            }
        }



        public void LoadHomeScreen() {
            View.LoadUserData(CurrentUser.Nickname, EntityUser.GetEntity(CurrentUser));

            List<EntityTask> pertinentTasks = EntityTask.GetEntityTasksList(TasksList.GetAppropriateTasks(CurrentUser, TaskUserFilter.ZoneAndJob));
            View.LoadTasksList(pertinentTasks, MainPage.TaskType.Pertinent, LoadList);

            List<EntityTask> doneTasks = EntityTask.GetEntityTasksList(TasksList.GetAcceptedTasks(CurrentUser.Nickname, AcTaskState.Done));
            Functions.GetTimeSpanHoursMinutes(doneTasks);
            View.LoadTasksList(doneTasks, MainPage.TaskType.Accepted, LoadList);

            List<EntityTask> reqTask = EntityTask.GetEntityTasksList(TasksList.GetRequestedTasks(CurrentUser.Nickname, RqTaskState.Done));
            Functions.GetTimeSpanHoursMinutes(reqTask);
            View.LoadTasksList(reqTask, MainPage.TaskType.Requested, LoadList);
        }

        public void DoubleClickLWRequestedTask(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromLV(MainPage.TaskType.Requested, LoadList);
            EntityUser eu = EntityUser.GetEntity(CurrentUser);

            View.OpenTaskDetailsForm(taskId, eu);
        }

        public void DoubleClickLWPertinentTask(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromLV(MainPage.TaskType.Pertinent, LoadList);
            EntityUser eu = EntityUser.GetEntity(CurrentUser);

            View.OpenTaskDetailsForm(taskId, eu);
        }

        public void DoubleClickLWAcceptedTask(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromLV(MainPage.TaskType.Accepted, LoadList);
            EntityUser eu = EntityUser.GetEntity(CurrentUser);

            View.OpenTaskDetailsForm(taskId, eu);
        }



        public void LoadReqAcceptTask() {
            Regex rxRicerca = new Regex(View.GetTextInTasksSearchBar(TaskType), RegexOptions.IgnoreCase);

            List<EntityTask> pertinentTasks = EntityTask.GetEntityTasksList(TasksList.GetAppropriateTasks(CurrentUser, TaskUserFilter.ZoneAndJob));
            List<EntityTask> pertinentFilteredTask = FilterTasks(pertinentTasks, rxRicerca, View.GetUsedTasksFilter(TaskType));

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
            string id;

            try {
                id = View.GetTaskIdFromLV(TaskType, LoadList);

                Task t = TasksList.GetTask(id);
                if (t == null)
                    throw new Exception("Errore durante accettazione task");

                CurrentUser.AcceptTask(t);
                TasksList.WriteJsonFile();

                LoadReqAcceptTask();

            } catch (Exception ex) {
                View.ErrorInRequestAccept($"{ex.Message}");
            }

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

            Regex rxRicerca = new Regex(View.GetTextInTasksSearchBar(TaskType), RegexOptions.IgnoreCase);

            List<EntityTask> doneTasks = EntityTask.GetEntityTasksList(TasksList.GetAcceptedTasks(CurrentUser.Nickname, taskState));
            List<EntityTask> doneFilteredTasks = FilterTasks(doneTasks, rxRicerca, View.GetUsedTasksFilter(TaskType));
            Functions.GetTimeSpanHoursMinutes(doneFilteredTasks);

            View.ClearListViewTask(TaskType, LoadList);
            View.LoadTasksList(doneFilteredTasks, TaskType, LoadList);
        }

        public void ReLoadAcceptedTasks(object sender, EventArgs e) {
            LoadAcceptedTasks();
        }

        public bool IsTaskDone(EntityTask e) {
            Task t = TasksList.GetTask(e.Field1);

            return t.Status == TPhase.Done;
        }



        public void LoadRequestedTasks() {
            RqTaskState taskState = View.GetUsedStateFilterInRequested();

            Regex rxRicerca = new Regex(View.GetTextInTasksSearchBar(TaskType), RegexOptions.IgnoreCase);

            List<EntityTask> requestedTasks = EntityTask.GetEntityTasksList(TasksList.GetRequestedTasks(CurrentUser.Nickname, taskState));
            List<EntityTask> requestedPertinentTasks = FilterTasks(requestedTasks, rxRicerca, View.GetUsedTasksFilter(TaskType));
            Functions.GetTimeSpanHoursMinutes(requestedPertinentTasks);

            View.ClearListViewTask(TaskType, LoadList);
            View.LoadTasksList(requestedPertinentTasks, TaskType, LoadList);
        }

        public void ReLoadRequestedTasks(object sender, EventArgs e) {
            LoadRequestedTasks();
        }

        public bool IsTaskAccepted(EntityTask e) {
            Task t = TasksList.GetTask(e.Field1);

            return t.Status == TPhase.Accepted;
        }



        public void DoubleClickOnAcceptUsersLW(object sender, MouseEventArgs e) {
            string uNick = View.GetUserNicknameInUsersListView();

            User u = UsersList.GetUser(uNick);
            EntityUser eu = EntityUser.GetEntity(u);
            EntityUser viewer = EntityUser.GetEntity(CurrentUser);

            if (View.GetUsersSwitchChecked() || View.GetUsedStateFilterInUsers() == UsersState.Registration)
                View.OpenSignUpForm(eu);
            else if (!View.GetUsersSwitchChecked())
                View.OpenUsersDetailsForm(eu, viewer);
        }

        public void LoadUsersTab() {
            UsersState uState = View.GetUsedStateFilterInUsers();
            UserDelta uDelta = View.GetUsedDeltaHoursFilterInUsers();

            Regex rxRicerca = new Regex(View.GetTextInUsersSearchBar(), RegexOptions.IgnoreCase);
            List<string> selectedJobs = View.GetSelectedJobsListInLV(MainPage.ViewType.Users);

            List<EntityUser> users = new List<EntityUser>();
            switch (uState) {
                case UsersState.Confirmed:
                    users = EntityUser.GetEntityUsersList(UsersList.GetUserBasedOnDeltaHours(uDelta));
                    break;
                case UsersState.Registration:
                    users = EntityUser.GetEntityUsersList(UsersList.GetInPhaseUsers(uState));
                    break;
            }

            List<EntityUser> filteredUsers = FilterUser(users, rxRicerca);
            filteredUsers = FilterUser(filteredUsers, selectedJobs);

            Functions.GetTimeSpanHoursMinutes(filteredUsers);

            View.LoadUsersList(filteredUsers, uState);

            FirstTimeInUsersTab = false;
        }

        public void ReLoadUsersTab(object sender, EventArgs e) {
            LoadUsersTab();
        }

        public void OnModifyDistr(object sender, EventArgs e) {
            View.ShowEditorForm(ItemsEditor.Use.Districts);
        }

        public void OnModifyJobs(object sender, EventArgs e) {
            View.ShowEditorForm(ItemsEditor.Use.Jobs);
        }

        public bool IsDeltaTimePositive(EntityUser e) {
            User u = UsersList.GetUser(e.Field1);
            return ((u.DoneHours - u.RecievedHours).TotalMinutes >= 0);
        }

        public void OnSelectAllUsersWorksList(object sender, EventArgs e) {
            View.SetCheckedInJobsList(true, MainPage.ViewType.Users);
        }

        public void OnDeselectAllUseresWorksList(object sender, EventArgs e) {
            View.SetCheckedInJobsList(false, MainPage.ViewType.Users);
        }

        public void ListViewJobsUsersCheckedChanged(object sender, ItemCheckedEventArgs e) {
            LoadUsersTab();
        }



        public bool IsSecretary() {
            return (CurrentUser.Level == UserLevel.Secretary);
        }

        public void DoubleClickDetailsLV(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromLV(TaskType, LoadList);
            EntityUser eu = EntityUser.GetEntity(CurrentUser);

            View.OpenTaskDetailsForm(taskId, eu);
        }

        public string GetDeltaTimeUser(EntityUser e) {
            User u = UsersList.GetUser(e.Field1);

            return $"{Math.Truncate(u.DeltaHours.TotalHours)} h {Math.Abs(u.DeltaHours.Minutes)}m";
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

        private List<EntityUser> FilterUser(List<EntityUser> input, Regex rx) {
            List<EntityUser> outp = new List<EntityUser>();

            for (int i = 0; i < input.Count; i++) {
                if (rx.IsMatch(input[i].Field1)) {
                    outp.Add(input[i]);
                }
            }

            return outp;
        }

        private List<EntityUser> FilterUser(List<EntityUser> input, List<string> jobs) {
            List<EntityUser> outp = new List<EntityUser>();

            for (int i = 0; i < input.Count; i++) {
                if (input[i].Field3.Intersect(jobs).Any()) {
                    outp.Add(input[i]);
                }
            }

            return outp;
        }
    }
}
