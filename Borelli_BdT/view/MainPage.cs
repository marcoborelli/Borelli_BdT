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
        public enum LoadTskList { //indica se la listView in questione e' nella HomeScreen (pochi dettagli) o nel tab dedicato (dettagliata)
            HomeScreen,
            Details,
        }
        public enum TaskType { //indica se e' la lista delle task pertinenti, richieste o fatte.
            Pertinent,
            Requested = 2,
            Done = 4,
        }
        /* La logica consiste in una lista di 6 listView (2 (HomeScreen e Details) per ognuno dei 3 task type
         * (Pertinent, Requested, Done)). Questi enumm, tramite la loro somma, vengono usati per riconoscere la giusta ListView
         * da parte del presenter che non vi ha accesso.
         * Es: la ListView che sitrova sull'Home delle task fatte avra' indice 4: 0(LoadTskList.HomeScreen) + 4(TaskType.Done) */


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
        private List<MaterialListView> MListViews { get; set; }
        private Color Giallino { get; set; }
        private Color Verdolino { get; set; }

        public MainPage(string username) {
            InitializeComponent();
            FormManager.AddForm(this);

            MListViews = new List<MaterialListView> { mListViewPertinentTask, mListViewPertinentComplete, mListViewReqJobs/*, mListViewReqJobsComplete, */, mListViewDoneJobs, mListViewDoneJobsComplete };

            Presenter = new MainPagePresenter(this, username);
            materialTabControl1.SelectedIndexChanged += new EventHandler(Presenter.LoadSelectedTab);

            textBoxSearchAcceptTask.TextChanged += new EventHandler(Presenter.ReLoadReqAcceptTask);
            mButtonAcceptTask.Click += new EventHandler(Presenter.OnAcceptTask);
            mButtonReqTask.Click += new EventHandler(Presenter.OnRequestTask);

            textBoxSearchDoneTasks.TextChanged += new EventHandler(Presenter.ReLoadReqDoneTask);

            mListViewAcceptUsers.MouseDoubleClick += new MouseEventHandler(Presenter.DoubleClickOnAcceptUsersLW);
            mButtonModDistr.Click += new EventHandler(Presenter.OnModifyDistr);
            mButtonModJobs.Click += new EventHandler(Presenter.OnModifyJobs);

            Verdolino = Color.FromArgb(192, 255, 192);
            Giallino = Color.FromArgb(255, 255, 192);
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



        public AcTaskState GetUsedStateFilter() {
            AcTaskState outp;

            if (tACCmRButtonAll.Checked) {
                outp = AcTaskState.All;
            } else if (tACCmRButtonDone.Checked) {
                outp = AcTaskState.Done;
            } else {
                outp = AcTaskState.Accepted;
            }

            return outp;
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
                                lwOutp = mListViewDoneJobsComplete;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field11, tsk[i].Field6, tsk[i].Field9 }); //id, richiedente, lavoro, data acc., ore

                                lvi.BackColor = Presenter.IsAcceptedTaskDone(tsk[i]) ? Verdolino : Giallino;
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
                                lwOutp = mListViewPertinentComplete;
                                lvi = new ListViewItem(new string[] { tsk[i].Field1, tsk[i].Field3, tsk[i].Field11, tsk[i].Field2 }); //id, richiedente, lavoro, descrizione
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

        public string GetTextInSearchBar(TaskType type) {
            string research = "";

            switch (type) {
                case TaskType.Pertinent:
                    research = textBoxSearchAcceptTask.Text;
                    break;
                case TaskType.Requested:
                    //TODO:
                    break;
                case TaskType.Done:
                    research = textBoxSearchDoneTasks.Text;
                    break;
            }

            return research;
        }

        public ResarchOption GetUsedFilter(TaskType type) {
            ResarchOption outp = ResarchOption.None;

            switch (type) {
                case TaskType.Pertinent:
                    outp = tARmRButtonJob.Checked ? ResarchOption.Job : ResarchOption.Requester;
                    break;
                case TaskType.Requested:
                    //TODO:
                    break;
                case TaskType.Done:
                    outp = tACCmRButtonJob.Checked ? ResarchOption.Job : ResarchOption.Requester;
                    break;
            }

            return outp;
        }

        public int GetSelectedTabIndex() {
            return materialTabControl1.SelectedIndex;
        }

        public string GetUserNicknameInUsersListView() {
            return mListViewAcceptUsers.SelectedItems[0].SubItems[0].Text;
        }
        public string GetTaskIdFromListView(TaskType type, LoadTskList how) { //di defualt tutti gli id si trovano sulla prima colonna
            MaterialListView m = GetCurrentListView(type, how);
            return m.SelectedItems[0].SubItems[0].Text;
        }

        public void ClearListViewTask(TaskType type, LoadTskList how) {
            MaterialListView m = GetCurrentListView(type, how);
            m.Items.Clear();
        }



        private void ClosedSignUpForm(object sender, FormClosedEventArgs e) {
            Presenter.LoadAcceptNewUserTab();
        }
        private MaterialListView GetCurrentListView(TaskType type, LoadTskList how) {
            return MListViews[(int)type + (int)how];
        }
    }
}
