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
        /* Logica nome colonne in ListView:
         * TASK:
         * <col><H(ome) | S(pecific)><P(ertinent) | A(ccepted) | R(equested) | T(ask all)><campo>
         *
         * USER:
         * <col><A(cceptation)><campo> */

        /* Logica nome radioButton:
         * <mRdBut><P(ertinent) | A(ccepted) | R(equested) | U(ser) | T(ask all)><SF(searchFilter) | VO (viewOnly)><campo> */


        public enum LoadTskList { //indica se la listView in questione e' nella HomeScreen (pochi dettagli) o nel tab dedicato (dettagliata)
            HomeScreen,
            Details,
        }
        public enum TaskType { //indica se e' la lista delle task pertinenti, richieste o accettate di fare.
            Pertinent,
            Requested = 2,
            Accepted = 4,
            All = 5,
        }
        /* La logica consiste in una lista di 6 listView (2 (HomeScreen e Details) per ognuno dei 3 task type
         * (Pertinent, Requested, Accepted)). Questi enum, tramite la loro somma, vengono usati per riconoscere la giusta ListView
         * da parte del presenter che non vi ha accesso direttamente.
         * Es: la ListView che si trova sull'Home delle task fatte avra' indice 4: 0(LoadTskList.HomeScreen) + 4(TaskType.Accepted) */


        public enum ResearchOption {
            None,
            Requester,
            Acceptor,
            Job,
        }

        public enum ViewType {
            Task,
            Users
        }


        private MainPagePresenter Presenter { get; set; }
        private List<ListView> MListViews { get; set; }
        private Color Giallino { get; set; }
        private Color Arancino { get; set; }
        private Color Verdolino { get; set; }

        private string[] ColumnsRequestedUsersLV { get; set; }
        private string[] ColumnsAcceptedUsersLV { get; set; }


        public MainPage(string username) {
            InitializeComponent();
            FormManager.AddForm(this);

            MListViews = new List<ListView> { listViewPertinentTasks, listViewPertinentComplete, listViewRequestedTasks, listViewRequestedComplete, listViewAcceptedTasks, listViewDoneComplete, listViewAllTasks };

            Presenter = new MainPagePresenter(this, username);

            if (!Presenter.IsSecretary()) {
                materialTabControl1.TabPages.Remove(tabAcceptUsers);
                materialTabControl1.TabPages.Remove(tabAllTasks);
            }

            materialTabControl1.SelectedIndexChanged += new EventHandler(Presenter.SelectedTabChanged);

            listViewAcceptedTasks.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickLWAcceptedTask);
            listViewPertinentTasks.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickLWPertinentTask);
            listViewRequestedTasks.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickLWRequestedTask);

            textBoxSearchAcceptTask.TextChanged += new EventHandler(Presenter.ReLoadReqAcceptTask);
            mButtonAcceptTask.Click += new EventHandler(Presenter.OnAcceptTask);
            mButtonReqTask.Click += new EventHandler(Presenter.OnRequestTask);
            mRdButPSFjob.CheckedChanged += new EventHandler(Presenter.ReLoadReqAcceptTask);
            mRdButPSFrequester.CheckedChanged += new EventHandler(Presenter.ReLoadReqAcceptTask);
            listViewPertinentComplete.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickDetailsLV);

            textBoxSearchAcceptedTasks.TextChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButASFjob.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButASFrequester.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButAVOaccepted.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButAVOall.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButAVOdone.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            listViewDoneComplete.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickDetailsLV);

            textBoxSearchRequestedTasks.TextChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRSFacceptor.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRSFjob.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRVOrequested.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRVOaccepted.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRVOdone.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRVOall.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            listViewRequestedComplete.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickDetailsLV);

            listViewAcceptUsers.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickOnAcceptUsersLW);
            listViewWorksUsersFilter.ItemChecked += new ItemCheckedEventHandler(Presenter.ListViewJobsUsersCheckedChanged);
            mButtonModDistr.Click += new EventHandler(Presenter.OnModifyDistr);
            mButtonModJobs.Click += new EventHandler(Presenter.OnModifyJobs);
            textBoxSearchUser.TextChanged += new EventHandler(Presenter.ReLoadUsersTab);
            mRdButUVOalredy.CheckedChanged += new EventHandler(Presenter.ReLoadUsersTab);
            mRdButUVOWait.CheckedChanged += new EventHandler(Presenter.ReLoadUsersTab);
            mButtonSelectAll.Click += new EventHandler(Presenter.OnSelectAllUsersWorksList);
            mButtonDeselectAll.Click += new EventHandler(Presenter.OnDeselectAllUseresWorksList);
            mRdButUVOnegDelta.CheckedChanged += new EventHandler(Presenter.ReLoadUsersTab);
            mRdButUVOposDelta.CheckedChanged += new EventHandler(Presenter.ReLoadUsersTab);
            mRdButUVOallDelta.CheckedChanged += new EventHandler(Presenter.ReLoadUsersTab);

            textBoxSearchAllTasks.TextChanged += new EventHandler(Presenter.ReLoadAllTasks);
            listViewAllTasks.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickDetailsLV);
            mRdButTSFacceptor.CheckedChanged += new EventHandler(Presenter.ReLoadAllTasks);
            mRdButTSFrequester.CheckedChanged += new EventHandler(Presenter.ReLoadAllTasks);
            mRdButTVOrequested.CheckedChanged += new EventHandler(Presenter.ReLoadAllTasks);
            mRdButTVOaccepted.CheckedChanged += new EventHandler(Presenter.ReLoadAllTasks);
            mRdButTVOdone.CheckedChanged += new EventHandler(Presenter.ReLoadAllTasks);
            mRdButTVOall.CheckedChanged += new EventHandler(Presenter.ReLoadAllTasks);
            mSwitchDateFilter.CheckedChanged += new EventHandler(Presenter.OnSwitchDateTime);
            dTimePickerStart.ValueChanged += new EventHandler(Presenter.ReLoadAllTasks);
            dTimePickerEnd.ValueChanged += new EventHandler(Presenter.ReLoadAllTasks);
            mButtonTselectAll.Click += new EventHandler(Presenter.OnSelectAllTasksWorksList);
            mButtonTdeselectAll.Click += new EventHandler(Presenter.OnDeselectAllTasksWorksList);
            listViewTasksWorksFilter.ItemChecked += new ItemCheckedEventHandler(Presenter.ListViewJobsTasksCheckedChanged);

            Verdolino = Color.FromArgb(192, 255, 192);
            Arancino = Color.FromArgb(255, 224, 192);
            Giallino = Color.FromArgb(255, 255, 192);

            ColumnsRequestedUsersLV = new string[] { "NICKNAME", "NOME", "COGNOME", "NUMERO CELL.", "MAIL" };
            ColumnsAcceptedUsersLV = new string[] { "NICKNAME", "NOME", "COGNOME", "LAVORI", "ORE FATTE", "ORE RICEV.", "DELTA" };

            LoadLegendPaletteAcceptedTask();
            LoadLegendPaletteRequestedTask();
            LoadLegendPaletteUsers();
            LoadLegendPaletteAllTasks();
        }


        public void LoadUserData(string username, EntityUser viewer) {
            if (mCardAccountInfo.Controls.Count > 0)
                mCardAccountInfo.Controls.Clear();

            UserDetails userDetailsForm = new UserDetails(username, viewer);
            userDetailsForm.TopLevel = false;
            mCardAccountInfo.Controls.Add(userDetailsForm);
            userDetailsForm.Show();
        }

        public void LoadJobsList(List<string> input) {
            if (input != null) {
                for (int i = 0; i < input.Count; i++) {
                    mComboBoxChooseJob.Items.Add(input[i]);

                    if (i == 0)
                        mComboBoxChooseJob.Text = input[i];
                }
            }
        }

        public void ErrorInRequestAccept(string message) {
            MessageBox.Show(message);
        }
        public List<string> GetReqestTaskFields() {
            return new List<string> { mComboBoxChooseJob.Text, mMultiLineTextBoxCaption.Text };
        }

        public void ResetRequestTaskFields() {
            mMultiLineTextBoxCaption.Text = String.Empty;
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

        public void OpenUsersDetailsForm(EntityUser toWatsh, EntityUser viewer) {
            UserDetails userDetailsForm = new UserDetails(toWatsh.Field1, viewer);
            userDetailsForm.ShowDialog();

            userDetailsForm.FormClosed += new FormClosedEventHandler(ClosedSignUpForm);
        }

        public UsersState GetUsedStateFilterInUsers() {
            UsersState outp;

            if (mRdButUVOWait.Checked) {
                outp = UsersState.Registration;
            } else {
                outp = UsersState.Confirmed;
            }

            return outp;
        }

        public UserDelta GetUsedDeltaHoursFilterInUsers() {
            UserDelta outp;

            if (mRdButUVOallDelta.Checked) {
                outp = UserDelta.All;
            } else if (mRdButUVOposDelta.Checked) {
                outp = UserDelta.Greater;
            } else {
                outp = UserDelta.Less;
            }

            return outp;
        }



        public AcTaskState GetUsedStateFilterInAccepted() {
            AcTaskState outp;

            if (mRdButAVOall.Checked) {
                outp = AcTaskState.All;
            } else if (mRdButAVOdone.Checked) {
                outp = AcTaskState.Done;
            } else {
                outp = AcTaskState.Accepted;
            }

            return outp;
        }



        public RqTaskState GetUsedStateFilterInRequested() {
            RqTaskState outp;

            if (mRdButRVOall.Checked) {
                outp = RqTaskState.All;
            } else if (mRdButRVOdone.Checked) {
                outp = RqTaskState.Done;
            } else if (mRdButRVOaccepted.Checked) {
                outp = RqTaskState.Accepted;
            } else {
                outp = RqTaskState.Requested;
            }

            return outp;
        }

        public void OpenTaskDetailsForm(string id, EntityUser e) {
            TaskDetails taskDetailsForm = new TaskDetails(id, e);
            taskDetailsForm.Show();

            taskDetailsForm.FormClosed += new FormClosedEventHandler(ClosedTaskDetailsForm);
        }



        public void LoadTasksList(List<EntityTask> tsk, TaskType type, LoadTskList how) {
            ListView lwOutp = new ListView();
            ListViewItem lvi = new ListViewItem();

            for (int i = 0; i < tsk.Count; i++) {
                switch (type) {
                    case TaskType.Accepted:
                        switch (how) {
                            case LoadTskList.HomeScreen:
                                lwOutp = listViewAcceptedTasks;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field9 }); //id, richiedente, ore
                                break;
                            case LoadTskList.Details:
                                lwOutp = listViewDoneComplete;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field11, tsk[i].Field6, tsk[i].Field9 }); //id, richiedente, lavoro, data acc., ore

                                lvi.BackColor = Presenter.IsTaskDone(tsk[i]) ? Verdolino : Giallino;
                                lvi.ForeColor = Color.Black;
                                break;
                        }
                        break;
                    case TaskType.Requested:
                        switch (how) {
                            case LoadTskList.HomeScreen:
                                lwOutp = listViewRequestedTasks;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field4, tsk[i].Field9 }); //id, donatore, ore
                                break;
                            case LoadTskList.Details:
                                lwOutp = listViewRequestedComplete;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field4, tsk[i].Field11, tsk[i].Field5, tsk[i].Field9 }); //id, donatore, lavoro, dataRichiesta, ore

                                if (Presenter.IsTaskDone(tsk[i])) {
                                    lvi.BackColor = Verdolino;
                                } else if (Presenter.IsTaskAccepted(tsk[i])) {
                                    lvi.BackColor = Giallino;
                                } else {
                                    lvi.BackColor = Arancino;
                                }

                                lvi.ForeColor = Color.Black;
                                break;
                        }
                        break;
                    case TaskType.Pertinent:
                        switch (how) {
                            case LoadTskList.HomeScreen:
                                lwOutp = listViewPertinentTasks;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field11 }); //id, richiedente, lavoro
                                break;
                            case LoadTskList.Details:
                                lwOutp = listViewPertinentComplete;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field11, tsk[i].Field2 }); //id, richiedente, lavoro, descrizione
                                break;
                        }
                        break;
                    case TaskType.All:
                        lwOutp = listViewAllTasks;
                        lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field4, tsk[i].Field11, tsk[i].Field5, tsk[i].Field9 }); //id, richiedente, acc, lavoro, data richiesta, ore

                        if (Presenter.IsTaskDone(tsk[i])) {
                            lvi.BackColor = Verdolino;
                        } else if (Presenter.IsTaskAccepted(tsk[i])) {
                            lvi.BackColor = Giallino;
                        } else {
                            lvi.BackColor = Arancino;
                        }

                        lvi.ForeColor = Color.Black;

                        break;
                }

                if (i == 0)
                    lwOutp.Items.Clear();

                lwOutp.Items.Add(lvi);

                if (i == tsk.Count - 1)
                    lwOutp.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public void LoadUsersList(List<EntityUser> usr, UsersState uState) {
            ListView lwOutp = listViewAcceptUsers;
            ListViewItem lvi = new ListViewItem();

            lwOutp.Items.Clear();
            SetUsersTab(uState, lwOutp);

            for (int i = 0; i < usr.Count; i++) {
                EntityCustomerMasterData tmp = usr[i].Field13;

                switch (uState) {
                    case UsersState.Registration:
                        lvi = new ListViewItem(new string[] { usr[i].Field1, tmp.Field1, tmp.Field2, tmp.Field3, tmp.Field4 }); //nickname, nome, cognome, num cell, mail
                        break;
                    case UsersState.Confirmed:
                        //nickname, nome, cognome, lavori, ore donate, ore ricevute, delta
                        string delta = Presenter.GetDeltaTimeUser(usr[i]);
                        lvi = new ListViewItem(new string[] { usr[i].Field1, tmp.Field1, tmp.Field2, EntityUser.WorksToString(usr[i], ", "), usr[i].Field8, usr[i].Field9, delta });

                        lvi.BackColor = Presenter.IsDeltaTimePositive(usr[i]) ? Verdolino : Arancino;
                        lvi.ForeColor = Color.Black;

                        break;
                }


                lwOutp.Items.Add(lvi);
            }

            lwOutp.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void LoadJobsListInUsersTab(List<string> input, ViewType vType) {
            switch (vType) { //TODO: mettere la possibilita' di aggiornare la lista solo se ci sono elementi nuovi
                case ViewType.Users:
                    for (int i = 0; i < input.Count; i++) {
                        if (i == 0)
                            listViewWorksUsersFilter.ItemChecked -= Presenter.ListViewJobsUsersCheckedChanged;

                        if (i == listViewWorksUsersFilter.Items.Count - 1)
                            listViewWorksUsersFilter.ItemChecked += Presenter.ListViewJobsUsersCheckedChanged;

                        listViewWorksUsersFilter.Items.Add(input[i]);
                    }
                    listViewWorksUsersFilter.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    break;
                case ViewType.Task:
                    for (int i = 0; i < input.Count; i++) {
                        if (i == 0)
                            listViewTasksWorksFilter.ItemChecked -= Presenter.ListViewJobsTasksCheckedChanged;

                        if (i == listViewTasksWorksFilter.Items.Count - 1)
                            listViewTasksWorksFilter.ItemChecked += Presenter.ListViewJobsTasksCheckedChanged;

                        listViewTasksWorksFilter.Items.Add(input[i]);
                    }
                    listViewTasksWorksFilter.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    break;
            }

        }

        public void SetCheckedInJobsList(bool check, ViewType vType) {
            switch (vType) {
                case ViewType.Users:
                    for (int i = 0; i < listViewWorksUsersFilter.Items.Count; i++) {
                        if (i == 0) //l'evento del ricaricare a ogni cambio check lo disabilito fino al penultimo
                            listViewWorksUsersFilter.ItemChecked -= Presenter.ListViewJobsUsersCheckedChanged;

                        if (i == listViewWorksUsersFilter.Items.Count - 1)
                            listViewWorksUsersFilter.ItemChecked += Presenter.ListViewJobsUsersCheckedChanged;

                        listViewWorksUsersFilter.Items[i].Checked = check;
                    }
                    break;
                case ViewType.Task:
                    for (int i = 0; i < listViewTasksWorksFilter.Items.Count; i++) {
                        if (i == 0)
                            listViewTasksWorksFilter.ItemChecked -= Presenter.ListViewJobsTasksCheckedChanged;

                        if (i == listViewTasksWorksFilter.Items.Count - 1)
                            listViewTasksWorksFilter.ItemChecked += Presenter.ListViewJobsTasksCheckedChanged;

                        listViewTasksWorksFilter.Items[i].Checked = check;
                    }
                    break;
            }
        }

        public List<string> GetSelectedJobsListInLV(ViewType vType) {
            List<string> outp = new List<string>();

            ListView lv = (vType == ViewType.Users) ? listViewWorksUsersFilter : listViewTasksWorksFilter;

            for (int i = 0; i < lv.CheckedItems.Count; i++) {
                outp.Add(lv.CheckedItems[i].SubItems[0].Text);
            }

            return outp;
        }

        public void SetUsersTab(UsersState eUState, ListView lv) {
            lv.Columns.Clear();

            switch (eUState) {
                case UsersState.Confirmed:
                    mCardUsersDebt.Visible = mCardUsersLegend.Visible = mSwitchOpenInModifyProfile.Visible = true;
                    for (int i = 0; i < ColumnsAcceptedUsersLV.Length; i++) {
                        lv.Columns.Add(ColumnsAcceptedUsersLV[i]);
                    }
                    break;
                case UsersState.Registration:
                    mCardUsersDebt.Visible = mCardUsersLegend.Visible = mSwitchOpenInModifyProfile.Visible = false;
                    for (int i = 0; i < ColumnsRequestedUsersLV.Length; i++) {
                        lv.Columns.Add(ColumnsRequestedUsersLV[i]);
                    }
                    break;
            }
        }

        public bool GetUsersSwitchChecked() {
            return mSwitchOpenInModifyProfile.Checked;
        }



        public string GetTextInTasksSearchBar(TaskType type) {
            string research = "";

            switch (type) {
                case TaskType.Pertinent:
                    research = textBoxSearchAcceptTask.Text;
                    break;
                case TaskType.Requested:
                    research = textBoxSearchRequestedTasks.Text;
                    break;
                case TaskType.Accepted:
                    research = textBoxSearchAcceptedTasks.Text;
                    break;
                case TaskType.All:
                    research = textBoxSearchAllTasks.Text;
                    break;
            }

            return research;
        }

        public string GetTextInUsersSearchBar() {
            return textBoxSearchUser.Text;
        }

        public TaskState GetUsedFilterInAllTasks() {
            TaskState outp;

            if (mRdButTVOall.Checked) {
                outp = TaskState.All;
            } else if (mRdButTVOdone.Checked) {
                outp = TaskState.Done;
            } else if (mRdButTVOaccepted.Checked) {
                outp = TaskState.Accepted;
            } else {
                outp = TaskState.Requested;
            }

            return outp;
        }



        public void SetDateTimePickersState(bool state) {
            dTimePickerStart.Enabled = dTimePickerEnd.Enabled = state;
        }

        public bool IsSwitchDateTimePickerChecked() {
            return mSwitchDateFilter.Checked;
        }

        public DateTime[] GetTaskDateFilterDates() {
            return new DateTime[] { dTimePickerStart.Value, dTimePickerEnd.Value };
        }


        public ResearchOption GetUsedTasksFilter(TaskType type) {
            ResearchOption outp = ResearchOption.None;

            switch (type) {
                case TaskType.Pertinent:
                    outp = mRdButPSFjob.Checked ? ResearchOption.Job : ResearchOption.Requester;
                    break;
                case TaskType.Requested:
                    outp = mRdButRSFjob.Checked ? ResearchOption.Job : ResearchOption.Acceptor;
                    break;
                case TaskType.Accepted:
                    outp = mRdButASFjob.Checked ? ResearchOption.Job : ResearchOption.Requester;
                    break;
                case TaskType.All:
                    outp = mRdButTSFacceptor.Checked ? ResearchOption.Acceptor : ResearchOption.Requester;
                    break;
            }

            return outp;
        }

        public int GetSelectedTabIndex() {
            return materialTabControl1.SelectedIndex;
        }

        public string GetUserNicknameInUsersListView() {
            return listViewAcceptUsers.SelectedItems[0].SubItems[0].Text;
        }
        public string GetTaskIdFromLV(TaskType type, LoadTskList how) { //di defualt tutti gli id si trovano sulla prima colonna
            ListView m = GetCurrentListView(type, how);

            if (m.SelectedItems.Count > 0) {
                return m.SelectedItems[0].SubItems[0].Text;
            } else {
                throw new Exception("Nessun indice selezionato");
            }

        }

        public void ClearListViewTask(TaskType type, LoadTskList how) {
            ListView m = GetCurrentListView(type, how);
            m.Items.Clear();
        }
        public void LoadLegendPaletteAcceptedTask() {
            SetLabelFont(labelDotAccepted);
            SetLabelFont(labelDotDone);

            labelDotAccepted.ForeColor = Giallino;
            labelDotDone.ForeColor = Verdolino;
        }

        public void LoadLegendPaletteRequestedTask() {
            SetLabelFont(labelDotClose);
            SetLabelFont(labelDotAcceptedR);
            SetLabelFont(labelDotRequested);

            labelDotClose.ForeColor = Verdolino;
            labelDotAcceptedR.ForeColor = Giallino;
            labelDotRequested.ForeColor = Arancino;
        }

        public void LoadLegendPaletteUsers() {
            SetLabelFont(labelDotUsersMinusDelta);
            SetLabelFont(labelDotUsersPlusDelta);

            labelDotUsersMinusDelta.ForeColor = Arancino;
            labelDotUsersPlusDelta.ForeColor = Verdolino;
        }

        public void LoadLegendPaletteAllTasks() {
            SetLabelFont(labelDotTrequested);
            SetLabelFont(labelDotTaccepted);
            SetLabelFont(labelDotTdone);

            labelDotTrequested.ForeColor = Arancino;
            labelDotTaccepted.ForeColor = Giallino;
            labelDotTdone.ForeColor = Verdolino;
        }



        private void ClosedTaskDetailsForm(object sender, FormClosedEventArgs e) {
            Presenter.LoadSelectedTab();
        }

        private void ClosedSignUpForm(object sender, FormClosedEventArgs e) {
            Presenter.LoadSelectedTab();
        }

        private ListView GetCurrentListView(TaskType type, LoadTskList how) {
            return MListViews[(int)type + (int)how];
        }

        private void SetLabelFont(Label l) {
            l.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
        }
    }
}
