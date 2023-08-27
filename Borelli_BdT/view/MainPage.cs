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
         * <col><H(ome) | S(pecific)><P(ertinent) | A(ccepted) | R(equested)><campo>
         *
         * USER:
         * <col><A(cceptation)><campo> */

        /* Logica nome radioButton:
         * <mRdBut><P(ertinent) | A(ccepted) | R(equested)><SF(searchFilter) | VO (viewOnly)><campo> */


        public enum LoadTskList { //indica se la listView in questione e' nella HomeScreen (pochi dettagli) o nel tab dedicato (dettagliata)
            HomeScreen,
            Details,
        }
        public enum TaskType { //indica se e' la lista delle task pertinenti, richieste o accettate di fare.
            Pertinent,
            Requested = 2,
            Accepted = 4,
        }
        /* La logica consiste in una lista di 6 listView (2 (HomeScreen e Details) per ognuno dei 3 task type
         * (Pertinent, Requested, Accepted)). Questi enumm, tramite la loro somma, vengono usati per riconoscere la giusta ListView
         * da parte del presenter che non vi ha accesso direttamente.
         * Es: la ListView che si trova sull'Home delle task fatte avra' indice 4: 0(LoadTskList.HomeScreen) + 4(TaskType.Accepted) */


        public enum LoadUsrList {
            ToAccept,
            Details,
        }

        public enum ResarchOption {
            None,
            Requester,
            Acceptor,
            Job,
        }


        private MainPagePresenter Presenter { get; set; }
        private List<ListView> MListViews { get; set; }
        private Color Giallino { get; set; }
        private Color Arancino { get; set; }
        private Color Verdolino { get; set; }

        public MainPage(string username) {
            InitializeComponent();
            FormManager.AddForm(this);

            MListViews = new List<ListView> { listViewPertinentTasks, listViewPertinentComplete, listViewRequestedTasks, listViewRequestedComplete, listViewAcceptedTasks, listViewDoneComplete };

            Presenter = new MainPagePresenter(this, username);
            materialTabControl1.SelectedIndexChanged += new EventHandler(Presenter.SelectedTabChanged);

            listViewAcceptedTasks.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickLWAcceptedTask);
            listViewPertinentTasks.MouseDoubleClick+= new MouseEventHandler(Presenter.DoubleClickLWPertinentTask);
            listViewRequestedTasks.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickLWRequestedTask);

            textBoxSearchAcceptTask.TextChanged += new EventHandler(Presenter.ReLoadReqAcceptTask);
            mButtonAcceptTask.Click += new EventHandler(Presenter.OnAcceptTask);
            mButtonReqTask.Click += new EventHandler(Presenter.OnRequestTask);
            mRdButPSFjob.CheckedChanged += new EventHandler(Presenter.ReLoadReqAcceptTask);
            mRdButPSFrequester.CheckedChanged += new EventHandler(Presenter.ReLoadReqAcceptTask);
            listViewPertinentComplete.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickLWPertinentCompleteTask);

            textBoxSearchAcceptedTasks.TextChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButASFjob.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButASFrequester.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButAVOaccepted.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButAVOall.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            mRdButAVOdone.CheckedChanged += new EventHandler(Presenter.ReLoadAcceptedTasks);
            listViewDoneComplete.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickLWAcceptedCompleteTask);

            textBoxSearchRequestedTasks.TextChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRSFacceptor.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRSFjob.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRVOrequested.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRVOaccepted.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRVOdone.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            mRdButRVOall.CheckedChanged += new EventHandler(Presenter.ReLoadRequestedTasks);
            listViewRequestedComplete.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickLWRequestedCompleteTask);

            listViewAcceptUsers.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickOnAcceptUsersLW);
            mButtonModDistr.Click += new EventHandler(Presenter.OnModifyDistr);
            mButtonModJobs.Click += new EventHandler(Presenter.OnModifyJobs);

            Verdolino = Color.FromArgb(192, 255, 192);
            Arancino = Color.FromArgb(255, 224, 192);
            Giallino = Color.FromArgb(255, 255, 192);

            LoadLegendPaletteAcceptedTask();
            LoadLegendPaletteRequestedTask();
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

            labelDeltaHours.Text = $"{delta.Hours}h {Math.Abs(delta.Minutes)}m";
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
                }

                if (i == 0)
                    lwOutp.Items.Clear();

                lwOutp.Items.Add(lvi);

                if (i == tsk.Count - 1)
                    lwOutp.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public void LoadUsersList(List<EntityUser> usr, LoadUsrList how) {
            ListView lwOutp = new ListView();
            ListViewItem lvi = new ListViewItem();

            for (int i = 0; i < usr.Count; i++) {
                switch (how) {
                    case LoadUsrList.ToAccept:
                        lwOutp = listViewAcceptUsers;

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

                if (i == usr.Count - 1)
                    lwOutp.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public string GetTextInSearchBar(TaskType type) {
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
            }

            return research;
        }

        public ResarchOption GetUsedFilter(TaskType type) {
            ResarchOption outp = ResarchOption.None;

            switch (type) {
                case TaskType.Pertinent:
                    outp = mRdButPSFjob.Checked ? ResarchOption.Job : ResarchOption.Requester;
                    break;
                case TaskType.Requested:
                    outp = mRdButRSFjob.Checked ? ResarchOption.Job : ResarchOption.Acceptor;
                    break;
                case TaskType.Accepted:
                    outp = mRdButASFjob.Checked ? ResarchOption.Job : ResarchOption.Requester;
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
        public string GetTaskIdFromListView(TaskType type, LoadTskList how) { //di defualt tutti gli id si trovano sulla prima colonna
            ListView m = GetCurrentListView(type, how);
            return m.SelectedItems[0].SubItems[0].Text;
        }

        public void ClearListViewTask(TaskType type, LoadTskList how) {
            ListView m = GetCurrentListView(type, how);
            m.Items.Clear();
        }
        public void LoadLegendPaletteAcceptedTask() {
            labelDotAccepted.ForeColor = Giallino;
            labelDotDone.ForeColor = Verdolino;
        }

        public void LoadLegendPaletteRequestedTask() {
            labelDotClose.ForeColor = Verdolino;
            labelDotAcceptedR.ForeColor = Giallino;
            labelDotRequested.ForeColor = Arancino;
        }



        private void ClosedTaskDetailsForm(object sender, FormClosedEventArgs e) {
            Presenter.LoadSelectedTab();
        }

        private void ClosedSignUpForm(object sender, FormClosedEventArgs e) {
            Presenter.LoadAcceptNewUserTab();
        }
        private ListView GetCurrentListView(TaskType type, LoadTskList how) {
            return MListViews[(int)type + (int)how];
        }
    }
}
