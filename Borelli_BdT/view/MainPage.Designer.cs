namespace Borelli_BdT.view {
    partial class MainPage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mCardUser = new MaterialSkin.Controls.MaterialCard();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.materialCard4 = new MaterialSkin.Controls.MaterialCard();
            this.materialCard5 = new MaterialSkin.Controls.MaterialCard();
            this.mLabelName = new MaterialSkin.Controls.MaterialLabel();
            this.mLabelSurname = new MaterialSkin.Controls.MaterialLabel();
            this.mLabelAddress = new MaterialSkin.Controls.MaterialLabel();
            this.mLabelDistr = new MaterialSkin.Controls.MaterialLabel();
            this.mListViewDoneJobs = new MaterialSkin.Controls.MaterialListView();
            this.mLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cdId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdRequester = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.mListViewReqJobs = new MaterialSkin.Controls.MaterialListView();
            this.crId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.crAcceptor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.crHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.labelDeltaHours = new System.Windows.Forms.Label();
            this.mLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.mListViewPertinentTask = new MaterialSkin.Controls.MaterialListView();
            this.cpId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpRequester = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpJob = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.materialTabControl1.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.mCardUser.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.materialCard5.SuspendLayout();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabHome);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(858, 563);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.materialCard1);
            this.tabHome.Controls.Add(this.materialCard5);
            this.tabHome.Controls.Add(this.materialCard4);
            this.tabHome.Controls.Add(this.materialCard3);
            this.tabHome.Controls.Add(this.materialCard2);
            this.tabHome.Controls.Add(this.mCardUser);
            this.tabHome.ImageKey = "home.png";
            this.tabHome.Location = new System.Drawing.Point(4, 39);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(850, 520);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "HOME";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(987, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home.png");
            // 
            // mCardUser
            // 
            this.mCardUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mCardUser.Controls.Add(this.pictureBoxPhoto);
            this.mCardUser.Controls.Add(this.mLabelDistr);
            this.mCardUser.Controls.Add(this.mLabelAddress);
            this.mCardUser.Controls.Add(this.mLabelSurname);
            this.mCardUser.Controls.Add(this.mLabelName);
            this.mCardUser.Depth = 0;
            this.mCardUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mCardUser.Location = new System.Drawing.Point(57, 17);
            this.mCardUser.Margin = new System.Windows.Forms.Padding(14);
            this.mCardUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.mCardUser.Name = "mCardUser";
            this.mCardUser.Padding = new System.Windows.Forms.Padding(14);
            this.mCardUser.Size = new System.Drawing.Size(318, 178);
            this.mCardUser.TabIndex = 0;
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.mLabel3);
            this.materialCard2.Controls.Add(this.mListViewPertinentTask);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(57, 223);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(318, 279);
            this.materialCard2.TabIndex = 1;
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.mLabel1);
            this.materialCard3.Controls.Add(this.mListViewDoneJobs);
            this.materialCard3.Depth = 0;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(455, 18);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard3.Size = new System.Drawing.Size(318, 192);
            this.materialCard3.TabIndex = 2;
            // 
            // materialCard4
            // 
            this.materialCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard4.Depth = 0;
            this.materialCard4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard4.Location = new System.Drawing.Point(455, 238);
            this.materialCard4.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard4.Name = "materialCard4";
            this.materialCard4.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard4.Size = new System.Drawing.Size(208, 44);
            this.materialCard4.TabIndex = 1;
            // 
            // materialCard5
            // 
            this.materialCard5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard5.Controls.Add(this.mLabel2);
            this.materialCard5.Controls.Add(this.mListViewReqJobs);
            this.materialCard5.Depth = 0;
            this.materialCard5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard5.Location = new System.Drawing.Point(455, 310);
            this.materialCard5.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard5.Name = "materialCard5";
            this.materialCard5.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard5.Size = new System.Drawing.Size(318, 192);
            this.materialCard5.TabIndex = 3;
            // 
            // mLabelName
            // 
            this.mLabelName.AutoSize = true;
            this.mLabelName.Depth = 0;
            this.mLabelName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelName.Location = new System.Drawing.Point(132, 12);
            this.mLabelName.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelName.Name = "mLabelName";
            this.mLabelName.Size = new System.Drawing.Size(96, 19);
            this.mLabelName.TabIndex = 1;
            this.mLabelName.Text = "mLabelName";
            // 
            // mLabelSurname
            // 
            this.mLabelSurname.AutoSize = true;
            this.mLabelSurname.Depth = 0;
            this.mLabelSurname.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelSurname.Location = new System.Drawing.Point(132, 41);
            this.mLabelSurname.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelSurname.Name = "mLabelSurname";
            this.mLabelSurname.Size = new System.Drawing.Size(107, 19);
            this.mLabelSurname.TabIndex = 2;
            this.mLabelSurname.Text = "materialLabel2";
            // 
            // mLabelAddress
            // 
            this.mLabelAddress.AutoSize = true;
            this.mLabelAddress.Depth = 0;
            this.mLabelAddress.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelAddress.Location = new System.Drawing.Point(132, 71);
            this.mLabelAddress.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelAddress.Name = "mLabelAddress";
            this.mLabelAddress.Size = new System.Drawing.Size(107, 19);
            this.mLabelAddress.TabIndex = 3;
            this.mLabelAddress.Text = "materialLabel3";
            // 
            // mLabelDistr
            // 
            this.mLabelDistr.AutoSize = true;
            this.mLabelDistr.Depth = 0;
            this.mLabelDistr.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelDistr.Location = new System.Drawing.Point(132, 101);
            this.mLabelDistr.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelDistr.Name = "mLabelDistr";
            this.mLabelDistr.Size = new System.Drawing.Size(107, 19);
            this.mLabelDistr.TabIndex = 4;
            this.mLabelDistr.Text = "materialLabel4";
            // 
            // mListViewDoneJobs
            // 
            this.mListViewDoneJobs.AutoSizeTable = false;
            this.mListViewDoneJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mListViewDoneJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mListViewDoneJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cdId,
            this.cdRequester,
            this.cdHours});
            this.mListViewDoneJobs.Depth = 0;
            this.mListViewDoneJobs.FullRowSelect = true;
            this.mListViewDoneJobs.HideSelection = false;
            this.mListViewDoneJobs.Location = new System.Drawing.Point(17, 34);
            this.mListViewDoneJobs.MinimumSize = new System.Drawing.Size(200, 100);
            this.mListViewDoneJobs.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mListViewDoneJobs.MouseState = MaterialSkin.MouseState.OUT;
            this.mListViewDoneJobs.Name = "mListViewDoneJobs";
            this.mListViewDoneJobs.OwnerDraw = true;
            this.mListViewDoneJobs.Size = new System.Drawing.Size(284, 150);
            this.mListViewDoneJobs.TabIndex = 0;
            this.mListViewDoneJobs.UseCompatibleStateImageBehavior = false;
            this.mListViewDoneJobs.View = System.Windows.Forms.View.Details;
            // 
            // mLabel1
            // 
            this.mLabel1.AutoSize = true;
            this.mLabel1.Depth = 0;
            this.mLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel1.Location = new System.Drawing.Point(17, 11);
            this.mLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(77, 19);
            this.mLabel1.TabIndex = 6;
            this.mLabel1.Text = "Task fatte:";
            // 
            // cdId
            // 
            this.cdId.Text = "ID";
            // 
            // cdRequester
            // 
            this.cdRequester.Text = "RICHIEDENTE";
            this.cdRequester.Width = 150;
            // 
            // cdHours
            // 
            this.cdHours.Text = "ORE";
            this.cdHours.Width = 74;
            // 
            // mLabel2
            // 
            this.mLabel2.AutoSize = true;
            this.mLabel2.Depth = 0;
            this.mLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel2.Location = new System.Drawing.Point(17, 11);
            this.mLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(103, 19);
            this.mLabel2.TabIndex = 8;
            this.mLabel2.Text = "Task richieste:";
            // 
            // mListViewReqJobs
            // 
            this.mListViewReqJobs.AutoSizeTable = false;
            this.mListViewReqJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mListViewReqJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mListViewReqJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.crId,
            this.crAcceptor,
            this.crHours});
            this.mListViewReqJobs.Depth = 0;
            this.mListViewReqJobs.FullRowSelect = true;
            this.mListViewReqJobs.HideSelection = false;
            this.mListViewReqJobs.Location = new System.Drawing.Point(17, 34);
            this.mListViewReqJobs.MinimumSize = new System.Drawing.Size(200, 100);
            this.mListViewReqJobs.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mListViewReqJobs.MouseState = MaterialSkin.MouseState.OUT;
            this.mListViewReqJobs.Name = "mListViewReqJobs";
            this.mListViewReqJobs.OwnerDraw = true;
            this.mListViewReqJobs.Size = new System.Drawing.Size(284, 150);
            this.mListViewReqJobs.TabIndex = 7;
            this.mListViewReqJobs.UseCompatibleStateImageBehavior = false;
            this.mListViewReqJobs.View = System.Windows.Forms.View.Details;
            // 
            // crId
            // 
            this.crId.Text = "ID";
            // 
            // crAcceptor
            // 
            this.crAcceptor.Text = "ACCETTATANTE";
            this.crAcceptor.Width = 150;
            // 
            // crHours
            // 
            this.crHours.Text = "ORE";
            this.crHours.Width = 74;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.labelDeltaHours);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(691, 238);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(82, 44);
            this.materialCard1.TabIndex = 2;
            // 
            // labelDeltaHours
            // 
            this.labelDeltaHours.AutoSize = true;
            this.labelDeltaHours.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeltaHours.Location = new System.Drawing.Point(2, 11);
            this.labelDeltaHours.Name = "labelDeltaHours";
            this.labelDeltaHours.Size = new System.Drawing.Size(63, 27);
            this.labelDeltaHours.TabIndex = 0;
            this.labelDeltaHours.Text = "DLT";
            // 
            // mLabel3
            // 
            this.mLabel3.AutoSize = true;
            this.mLabel3.Depth = 0;
            this.mLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel3.Location = new System.Drawing.Point(17, 11);
            this.mLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(110, 19);
            this.mLabel3.TabIndex = 8;
            this.mLabel3.Text = "Task pertinenti:";
            // 
            // mListViewPertinentTask
            // 
            this.mListViewPertinentTask.AutoSizeTable = false;
            this.mListViewPertinentTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mListViewPertinentTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mListViewPertinentTask.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cpId,
            this.cpRequester,
            this.cpJob});
            this.mListViewPertinentTask.Depth = 0;
            this.mListViewPertinentTask.FullRowSelect = true;
            this.mListViewPertinentTask.HideSelection = false;
            this.mListViewPertinentTask.Location = new System.Drawing.Point(17, 34);
            this.mListViewPertinentTask.MinimumSize = new System.Drawing.Size(200, 100);
            this.mListViewPertinentTask.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mListViewPertinentTask.MouseState = MaterialSkin.MouseState.OUT;
            this.mListViewPertinentTask.Name = "mListViewPertinentTask";
            this.mListViewPertinentTask.OwnerDraw = true;
            this.mListViewPertinentTask.Size = new System.Drawing.Size(284, 150);
            this.mListViewPertinentTask.TabIndex = 7;
            this.mListViewPertinentTask.UseCompatibleStateImageBehavior = false;
            this.mListViewPertinentTask.View = System.Windows.Forms.View.Details;
            // 
            // cpId
            // 
            this.cpId.Text = "ID";
            // 
            // cpRequester
            // 
            this.cpRequester.Text = "RICHIEDENTE";
            this.cpRequester.Width = 135;
            // 
            // cpJob
            // 
            this.cpJob.Text = "LAVORO";
            this.cpJob.Width = 89;
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(13, 13);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(113, 155);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 6;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 630);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "MainPage";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 3, 3);
            this.Text = "MainPage";
            this.materialTabControl1.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.mCardUser.ResumeLayout(false);
            this.mCardUser.PerformLayout();
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.materialCard3.ResumeLayout(false);
            this.materialCard3.PerformLayout();
            this.materialCard5.ResumeLayout(false);
            this.materialCard5.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
        private MaterialSkin.Controls.MaterialCard materialCard5;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialCard mCardUser;
        private MaterialSkin.Controls.MaterialLabel mLabelDistr;
        private MaterialSkin.Controls.MaterialLabel mLabelAddress;
        private MaterialSkin.Controls.MaterialLabel mLabelSurname;
        private MaterialSkin.Controls.MaterialLabel mLabelName;
        private MaterialSkin.Controls.MaterialLabel mLabel1;
        private MaterialSkin.Controls.MaterialListView mListViewDoneJobs;
        private System.Windows.Forms.ColumnHeader cdId;
        private System.Windows.Forms.ColumnHeader cdRequester;
        private System.Windows.Forms.ColumnHeader cdHours;
        private MaterialSkin.Controls.MaterialLabel mLabel2;
        private MaterialSkin.Controls.MaterialListView mListViewReqJobs;
        private System.Windows.Forms.ColumnHeader crId;
        private System.Windows.Forms.ColumnHeader crAcceptor;
        private System.Windows.Forms.ColumnHeader crHours;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.Label labelDeltaHours;
        private MaterialSkin.Controls.MaterialLabel mLabel3;
        private MaterialSkin.Controls.MaterialListView mListViewPertinentTask;
        private System.Windows.Forms.ColumnHeader cpId;
        private System.Windows.Forms.ColumnHeader cpRequester;
        private System.Windows.Forms.ColumnHeader cpJob;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
    }
}