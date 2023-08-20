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
        public MainPage(string username) {
            InitializeComponent();
            FormManager.AddForm(this);

            MainPagePresenter p = new MainPagePresenter(this, username);
        }

        public void ChargeUserData(EntityCustomerMasterData e, string photoPhat) {
            pictureBoxPhoto.ImageLocation = photoPhat;
            mLabelName.Text = e.Field1;
            mLabelSurname.Text = e.Field2;
            mLabelAddress.Text = e.Field5;
            mLabelDistr.Text = e.Field6;
        }

        public void ChargeDoneTasks(List<EntityTask> tsk) {
            for (int i = 0; i < tsk.Count; i++) {
                ListViewItem tmp = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field2, tsk[i].Field8 });
                mListViewDoneJobs.Items.Add(tmp);
            }
        }

        public void ChargeRequestedTasks(List<EntityTask> tsk) {
            for (int i = 0; i < tsk.Count; i++) {
                ListViewItem tmp = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field8 });
                mListViewReqJobs.Items.Add(tmp);
            }
        }

        public void ChargeAppropriateTasks(List<EntityTask> tsk) {
            for (int i = 0; i < tsk.Count; i++) {
                ListViewItem tmp = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field2, tsk[i].Field10 });
                mListViewPertinentTask.Items.Add(tmp);
            }
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
    }
}
