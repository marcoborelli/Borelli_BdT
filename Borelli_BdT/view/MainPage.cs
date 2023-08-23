using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Borelli_BdT.presenter;
using Borelli_BdT.utilities;

namespace Borelli_BdT.view {
    public partial class MainPage : MaterialForm {
        public enum LoadTskList {
            HomeScreen,
            Details,
        }
        public enum TaskType {
            Done,
            Requested,
            Pertinent,
        }

        public enum LoadUsrList {
            ToAccept,
            Details,
        }

        MainPagePresenter Presenter { get; set; }
        public MainPage(string username) {
            InitializeComponent();
            FormManager.AddForm(this);

            Presenter = new MainPagePresenter(this, username);
            materialTabControl1.SelectedIndexChanged += new EventHandler(Presenter.LoadSelectedTab);

            mListViewAcceptUsers.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickOnAcceptUsersLW);
            mButtonModDistr.Click += new EventHandler(Presenter.OnModifyDistr);
            mButtonModJobs.Click += new EventHandler(Presenter.OnModifyJobs);
        }


        public void ChargeUserData(EntityCustomerMasterData e, string photoPhat) {
            pictureBoxPhoto.ImageLocation = photoPhat;
            mLabelName.Text = e.Field1;
            mLabelSurname.Text = e.Field2;
            mLabelAddress.Text = e.Field5;
            mLabelDistr.Text = e.Field6;
        }

        public void WriteDeltaHours(TimeSpan delta) {
            if (delta.TotalMinutes < 0) {
                labelDeltaHours.ForeColor = Color.Red;
            } else if (delta.TotalMinutes > 0) {
                labelDeltaHours.ForeColor = Color.Green;
            }
            labelDeltaHours.Font = new Font("Cooper Black", 14);

            labelDeltaHours.Text = $"{delta.Hours}h {delta.Minutes}m";
        }

        public void LoadTasksList(List<EntityTask> tsk, TaskType type, LoadTskList how) {
            MaterialListView lwOutp = new MaterialListView();
            ListViewItem lvi = new ListViewItem();

            for (int i = 0; i < tsk.Count; i++) {
                switch (type) {
                    case TaskType.Done:
                        switch (how) {
                            case LoadTskList.HomeScreen:
                                lwOutp = mListViewDoneJobs;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field9 }); //id, richiedente, ore
                                break;
                            case LoadTskList.Details:
                                //TODO
                                break;
                        }
                        break;
                    case TaskType.Requested:
                        switch (how) {
                            case LoadTskList.HomeScreen:
                                lwOutp = mListViewReqJobs;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field4, tsk[i].Field9 }); //id, donatore, ore
                                break;
                            case LoadTskList.Details:
                                //TODO
                                break;
                        }
                        break;
                    case TaskType.Pertinent:
                        switch (how) {
                            case LoadTskList.HomeScreen:
                                lwOutp = mListViewPertinentTask;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field11 }); //id, richiedente, lavoro
                                break;
                            case LoadTskList.Details:
                                //TODO
                                break;
                        }
                        break;
                }

                if (i == 0)
                    lwOutp.Items.Clear();

                lwOutp.Items.Add(lvi);
            }
        }


        public void LoadUsersList(List<EntityUser> usr, LoadUsrList how) {
            MaterialListView lwOutp = new MaterialListView();
            ListViewItem lvi = new ListViewItem();

            for (int i = 0; i < usr.Count; i++) {
                switch (how) {
                    case LoadUsrList.ToAccept:
                        lwOutp = mListViewAcceptUsers;

                        EntityCustomerMasterData tmp = usr[i].Field11;
                        lvi = new ListViewItem(new string[] { usr[i].Field1, tmp.Field1, tmp.Field2, tmp.Field3, tmp.Field4 });
                        break;
                    case LoadUsrList.Details:
                        //TODO
                        break;
                }

                if (i == 0)
                    lwOutp.Items.Clear();

                lwOutp.Items.Add(lvi);
            }
        }

        public void ShowEditorForm(ItemsEditor.Use use) {
            ItemsEditor itmsForm = new ItemsEditor(use);
            itmsForm.Show();
        }

        public void OpenSignUpForm(EntityUser e) {
            SignUp signUpForm = new SignUp(e);
            signUpForm.Show();

            signUpForm.FormClosed += new FormClosedEventHandler(ClosedSignUpForm);
        }




        public int GetSelectedTabIndex() {
            return materialTabControl1.SelectedIndex;
        }
        public string GetUserNicknameInUsersListView() {
            return mListViewAcceptUsers.SelectedItems[0].SubItems[0].Text;
        }

        private void ClosedSignUpForm(object sender, FormClosedEventArgs e) {
            Presenter.LoadAcceptNewUserTab();
        }
    }
}
