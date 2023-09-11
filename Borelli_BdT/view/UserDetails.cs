using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Borelli_BdT.presenter;
using Borelli_BdT.utilities;

namespace Borelli_BdT.view {
    public partial class UserDetails : MaterialForm {
        public enum FormState {
            OwnProfile,
            OtherProfile,
        }

        public enum TasksType {
            Requested,
            Done,
        }


        public EntityUser CurrentUser {
            set {
                this.Text = value.Field1;
                mMultiLineTextBoxOfferedJobs.Text = String.Join("; ", value.Field3);
                mMultiLineTextBoxDistricts.Text = String.Join("; ", value.Field4);
                mLabelTotalStars.Text = $"Stelle tot: {value.Field5}";
                labelAverageStars.Text = $"{value.Field6} stelle";
                mLabelNumbTsk.Text = $"Numero task: {value.Field7}";
                mLabelDoneHours.Text = $"Ore fatte: {value.Field8}";
                mLabelRecievedHours.Text = $"Ore ricevute: {value.Field9}";
                CurrentData = value.Field13;
            }
        }
        public EntityCustomerMasterData CurrentData {
            set {
                mLabelName.Text = value.Field1;
                mLabelSurname.Text = value.Field2;
                mLabelPhNumb.Text = value.Field3;
                mLabelMail.Text = value.Field4;
                mLabelAddress.Text = value.Field5;
            }
        }
        private UserDetailsPresenter Presenter { get; set; }
        public FormState FState { get; private set; }

        public UserDetails(string username, EntityUser viewer) {
            InitializeComponent();
            FormManager.AddForm(this);

            Presenter = new UserDetailsPresenter(this, username, viewer);
            materialTabControl1.SelectedIndexChanged += new EventHandler(Presenter.SelectedTabChanged);
            listViewDoneTasks.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickDoneLV);
            listViewRequestedTasks.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickRequestedLV);

            FState = UserDetailsPresenter.GetFormState(username, viewer);
            Presenter.SetForm();

            SetFontAndColorToLabels();
        }



        public void LoadUserData(EntityUser e, string photoPath, TimeSpan deltaHours) {
            pictureBoxPhoto.ImageLocation = photoPath;
            pictureBoxPhoto.BorderStyle = BorderStyle.None;

            CurrentUser = e;
            WriteDeltaHours(deltaHours);
        }




        public void LoadTasksList(List<EntityTask> tsk, TasksType type) {
            ListView lwOutp = new ListView();
            ListViewItem lvi = new ListViewItem();

            for (int i = 0; i < tsk.Count; i++) {
                switch (type) {
                    case TasksType.Requested:
                        lwOutp = listViewRequestedTasks;
                        lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field4, tsk[i].Field9 }); //id, donatore, ore
                        break;
                    case TasksType.Done:
                        lwOutp = listViewDoneTasks;
                        lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field9 }); //id, richiedente, ore
                        break;
                }

                if (i == 0)
                    lwOutp.Items.Clear();

                lwOutp.Items.Add(lvi);

                if (i == tsk.Count - 1)
                    lwOutp.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public void OpenTaskDetailsForm(string taskId, EntityUser e) {
            TaskDetails taskDetailsForm = new TaskDetails(taskId, e);
            taskDetailsForm.Show();
        }

        public string GetTaskIdFromLV(TasksType type) {
            string outp = String.Empty;

            switch(type) {
                case TasksType.Requested:
                    outp = listViewRequestedTasks.SelectedItems[0].SubItems[0].Text;
                    break;
                case TasksType.Done:
                    outp = listViewDoneTasks.SelectedItems[0].SubItems[0].Text;
                    break;
            }

            return outp;
        }




        public int GetSelectedTabIndex() {
            return materialTabControl1.SelectedIndex;
        }

        public void NoTabControl() {
            this.DrawerTabControl = null;
            this.DrawerShowIconsWhenHidden = false;
            this.FormStyle = FormStyles.StatusAndActionBar_None;
        }

        private void WriteDeltaHours(TimeSpan delta) {
            if (delta.TotalMinutes < 0) {
                labelDeltaHours.ForeColor = Color.Red;
            } else if (delta.TotalMinutes > 0) {
                labelDeltaHours.ForeColor = Color.Green;
            }

            labelDeltaHours.Text = Functions.GetTimeSpanHoursMinutes(delta);
        }

        private void SetFontAndColorToLabels() {
            labelDeltaHours.Font = new Font("Cooper Black", 22);

            labelAverageStars.Font = new Font("Cooper Black", 22);
            labelAverageStars.ForeColor = Color.FromArgb(255, 204, 0);
        }
    }
}
