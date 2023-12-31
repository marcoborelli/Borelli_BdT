﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Borelli_BdT.model;
using Borelli_BdT.utilities;
using Borelli_BdT.view;

namespace Borelli_BdT.presenter {
    public class UserDetailsPresenter {
        private UserDetails _view;
        private User CurrentUser { get; set; }
        private User Viewer { get; set; }

        public UserDetailsPresenter(UserDetails view, string username, EntityUser viewer) {
            View = view;
            CurrentUser = UsersList.GetUser(username);

            if (CurrentUser == null)
                throw new Exception("Inserire un utente valido");

            Viewer = UsersList.GetUser(viewer.Field1);

            LoadSelectedTab();
        }

        private UserDetails View {
            get => _view;
            set => _view = (value != null) ? value : throw new Exception("Inserire un attributo view valido");
        }



        public void DoubleClickDoneLV(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromLV(UserDetails.TasksType.Done);
            EntityUser eu = EntityUser.GetEntity(Viewer);

            View.OpenTaskDetailsForm(taskId, eu);
        }

        public void DoubleClickRequestedLV(object sender, MouseEventArgs e) {
            string taskId = View.GetTaskIdFromLV(UserDetails.TasksType.Requested);
            EntityUser eu = EntityUser.GetEntity(Viewer);

            View.OpenTaskDetailsForm(taskId, eu);
        }

        public void SelectedTabChanged(object sender, EventArgs e) {
            LoadSelectedTab();
        }

        public void LoadSelectedTab() {
            int tabIndex = View.GetSelectedTabIndex();

            switch (tabIndex) {
                case 0:
                    LoadUserData();
                    break;
                case 1:
                    LoadTasks();
                    break;
            }
        }



        public static UserDetails.FormState GetFormState(string username, EntityUser viewer) {
            return (viewer.Field1 == username) ? UserDetails.FormState.OwnProfile : UserDetails.FormState.OtherProfile;
        }

        public void SetForm() {
            switch (View.FState) {
                case UserDetails.FormState.OwnProfile: //se sto vedendo il mio profilo non mi importa di vedere le ultime task fatte - ricevute
                    View.NoTabControl();
                    break;
            }
        }

        private void LoadUserData() {
            EntityUser e = EntityUser.GetEntity(CurrentUser);
            Functions.GetTimeSpanHoursMinutes(e);

            View.LoadUserData(e, Parameters.GetCompleteImagePath(CurrentUser.Nickname), CurrentUser.DeltaHours);
        }

        private void LoadTasks() {
            List<EntityTask> doneTasks = EntityTask.GetEntityTasksList(TasksList.GetAcceptedTasks(CurrentUser.Nickname, AcTaskState.Done));
            Functions.GetTimeSpanHoursMinutes(doneTasks);
            View.LoadTasksList(doneTasks, UserDetails.TasksType.Done);

            List<EntityTask> reqTask = EntityTask.GetEntityTasksList(TasksList.GetRequestedTasks(CurrentUser.Nickname, RqTaskState.Done));
            Functions.GetTimeSpanHoursMinutes(reqTask);
            View.LoadTasksList(reqTask, UserDetails.TasksType.Requested);
        }
    }
}
