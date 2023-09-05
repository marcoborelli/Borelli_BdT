namespace Borelli_BdT.view {
    partial class UserDetails {
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
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabInfoUser = new System.Windows.Forms.TabPage();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.labelAverageStars = new System.Windows.Forms.Label();
            this.mLabelTotalStars = new MaterialSkin.Controls.MaterialLabel();
            this.mLabelNumbTsk = new MaterialSkin.Controls.MaterialLabel();
            this.mMultiLineTextBoxDistricts = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.mMultiLineTextBoxOfferedJobs = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.labelDeltaHours = new System.Windows.Forms.Label();
            this.mLabelRecievedHours = new MaterialSkin.Controls.MaterialLabel();
            this.mLabelDoneHours = new MaterialSkin.Controls.MaterialLabel();
            this.mCardUser = new MaterialSkin.Controls.MaterialCard();
            this.mLabelMail = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.mLabelPhNumb = new MaterialSkin.Controls.MaterialLabel();
            this.mLabelAddress = new MaterialSkin.Controls.MaterialLabel();
            this.mLabelSurname = new MaterialSkin.Controls.MaterialLabel();
            this.mLabelName = new MaterialSkin.Controls.MaterialLabel();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.listViewRequestedTasks = new System.Windows.Forms.ListView();
            this.colRid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRacceptor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRhours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.listViewDoneTasks = new System.Windows.Forms.ListView();
            this.colAid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArequester = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAhours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabControl1.SuspendLayout();
            this.tabInfoUser.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.mCardUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.tabTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabInfoUser);
            this.materialTabControl1.Controls.Add(this.tabTasks);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(386, 482);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabInfoUser
            // 
            this.tabInfoUser.Controls.Add(this.materialLabel2);
            this.tabInfoUser.Controls.Add(this.materialLabel1);
            this.tabInfoUser.Controls.Add(this.materialCard2);
            this.tabInfoUser.Controls.Add(this.mMultiLineTextBoxDistricts);
            this.tabInfoUser.Controls.Add(this.mMultiLineTextBoxOfferedJobs);
            this.tabInfoUser.Controls.Add(this.materialCard1);
            this.tabInfoUser.Controls.Add(this.mCardUser);
            this.tabInfoUser.Location = new System.Drawing.Point(4, 22);
            this.tabInfoUser.Name = "tabInfoUser";
            this.tabInfoUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfoUser.Size = new System.Drawing.Size(378, 456);
            this.tabInfoUser.TabIndex = 0;
            this.tabInfoUser.Text = "DATI";
            this.tabInfoUser.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.labelAverageStars);
            this.materialCard2.Controls.Add(this.mLabelTotalStars);
            this.materialCard2.Controls.Add(this.mLabelNumbTsk);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(10, 256);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(368, 65);
            this.materialCard2.TabIndex = 2;
            // 
            // labelAverageStars
            // 
            this.labelAverageStars.AutoSize = true;
            this.labelAverageStars.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageStars.Location = new System.Drawing.Point(14, 8);
            this.labelAverageStars.Name = "labelAverageStars";
            this.labelAverageStars.Size = new System.Drawing.Size(130, 36);
            this.labelAverageStars.TabIndex = 2;
            this.labelAverageStars.Text = "MEDIA";
            // 
            // mLabelTotalStars
            // 
            this.mLabelTotalStars.AutoSize = true;
            this.mLabelTotalStars.Depth = 0;
            this.mLabelTotalStars.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelTotalStars.Location = new System.Drawing.Point(227, 35);
            this.mLabelTotalStars.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelTotalStars.Name = "mLabelTotalStars";
            this.mLabelTotalStars.Size = new System.Drawing.Size(128, 19);
            this.mLabelTotalStars.TabIndex = 1;
            this.mLabelTotalStars.Text = "mLabelTotalStars";
            // 
            // mLabelNumbTsk
            // 
            this.mLabelNumbTsk.AutoSize = true;
            this.mLabelNumbTsk.Depth = 0;
            this.mLabelNumbTsk.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelNumbTsk.Location = new System.Drawing.Point(227, 8);
            this.mLabelNumbTsk.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelNumbTsk.Name = "mLabelNumbTsk";
            this.mLabelNumbTsk.Size = new System.Drawing.Size(123, 19);
            this.mLabelNumbTsk.TabIndex = 0;
            this.mLabelNumbTsk.Text = "mLabelNumbTsk";
            // 
            // mMultiLineTextBoxDistricts
            // 
            this.mMultiLineTextBoxDistricts.AnimateReadOnly = false;
            this.mMultiLineTextBoxDistricts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mMultiLineTextBoxDistricts.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mMultiLineTextBoxDistricts.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mMultiLineTextBoxDistricts.Depth = 0;
            this.mMultiLineTextBoxDistricts.HideSelection = true;
            this.mMultiLineTextBoxDistricts.Hint = "Zone competenza";
            this.mMultiLineTextBoxDistricts.Location = new System.Drawing.Point(211, 353);
            this.mMultiLineTextBoxDistricts.MaxLength = 32767;
            this.mMultiLineTextBoxDistricts.MouseState = MaterialSkin.MouseState.OUT;
            this.mMultiLineTextBoxDistricts.Name = "mMultiLineTextBoxDistricts";
            this.mMultiLineTextBoxDistricts.PasswordChar = '\0';
            this.mMultiLineTextBoxDistricts.ReadOnly = true;
            this.mMultiLineTextBoxDistricts.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mMultiLineTextBoxDistricts.SelectedText = "";
            this.mMultiLineTextBoxDistricts.SelectionLength = 0;
            this.mMultiLineTextBoxDistricts.SelectionStart = 0;
            this.mMultiLineTextBoxDistricts.ShortcutsEnabled = true;
            this.mMultiLineTextBoxDistricts.Size = new System.Drawing.Size(171, 100);
            this.mMultiLineTextBoxDistricts.TabIndex = 6;
            this.mMultiLineTextBoxDistricts.TabStop = false;
            this.mMultiLineTextBoxDistricts.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mMultiLineTextBoxDistricts.UseSystemPasswordChar = false;
            // 
            // mMultiLineTextBoxOfferedJobs
            // 
            this.mMultiLineTextBoxOfferedJobs.AnimateReadOnly = false;
            this.mMultiLineTextBoxOfferedJobs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mMultiLineTextBoxOfferedJobs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mMultiLineTextBoxOfferedJobs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mMultiLineTextBoxOfferedJobs.Depth = 0;
            this.mMultiLineTextBoxOfferedJobs.HideSelection = true;
            this.mMultiLineTextBoxOfferedJobs.Hint = "Lavori offerti";
            this.mMultiLineTextBoxOfferedJobs.Location = new System.Drawing.Point(10, 353);
            this.mMultiLineTextBoxOfferedJobs.MaxLength = 32767;
            this.mMultiLineTextBoxOfferedJobs.MouseState = MaterialSkin.MouseState.OUT;
            this.mMultiLineTextBoxOfferedJobs.Name = "mMultiLineTextBoxOfferedJobs";
            this.mMultiLineTextBoxOfferedJobs.PasswordChar = '\0';
            this.mMultiLineTextBoxOfferedJobs.ReadOnly = true;
            this.mMultiLineTextBoxOfferedJobs.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mMultiLineTextBoxOfferedJobs.SelectedText = "";
            this.mMultiLineTextBoxOfferedJobs.SelectionLength = 0;
            this.mMultiLineTextBoxOfferedJobs.SelectionStart = 0;
            this.mMultiLineTextBoxOfferedJobs.ShortcutsEnabled = true;
            this.mMultiLineTextBoxOfferedJobs.Size = new System.Drawing.Size(171, 100);
            this.mMultiLineTextBoxOfferedJobs.TabIndex = 4;
            this.mMultiLineTextBoxOfferedJobs.TabStop = false;
            this.mMultiLineTextBoxOfferedJobs.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mMultiLineTextBoxOfferedJobs.UseSystemPasswordChar = false;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.labelDeltaHours);
            this.materialCard1.Controls.Add(this.mLabelRecievedHours);
            this.materialCard1.Controls.Add(this.mLabelDoneHours);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(10, 175);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(368, 77);
            this.materialCard1.TabIndex = 1;
            // 
            // labelDeltaHours
            // 
            this.labelDeltaHours.AutoSize = true;
            this.labelDeltaHours.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeltaHours.Location = new System.Drawing.Point(223, 25);
            this.labelDeltaHours.Name = "labelDeltaHours";
            this.labelDeltaHours.Size = new System.Drawing.Size(83, 36);
            this.labelDeltaHours.TabIndex = 2;
            this.labelDeltaHours.Text = "DLT";
            // 
            // mLabelRecievedHours
            // 
            this.mLabelRecievedHours.AutoSize = true;
            this.mLabelRecievedHours.Depth = 0;
            this.mLabelRecievedHours.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelRecievedHours.Location = new System.Drawing.Point(17, 41);
            this.mLabelRecievedHours.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelRecievedHours.Name = "mLabelRecievedHours";
            this.mLabelRecievedHours.Size = new System.Drawing.Size(159, 19);
            this.mLabelRecievedHours.TabIndex = 1;
            this.mLabelRecievedHours.Text = "mLabelRecievedHours";
            // 
            // mLabelDoneHours
            // 
            this.mLabelDoneHours.AutoSize = true;
            this.mLabelDoneHours.Depth = 0;
            this.mLabelDoneHours.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelDoneHours.Location = new System.Drawing.Point(17, 14);
            this.mLabelDoneHours.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelDoneHours.Name = "mLabelDoneHours";
            this.mLabelDoneHours.Size = new System.Drawing.Size(133, 19);
            this.mLabelDoneHours.TabIndex = 0;
            this.mLabelDoneHours.Text = "mLabelDoneHours";
            // 
            // mCardUser
            // 
            this.mCardUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mCardUser.Controls.Add(this.mLabelMail);
            this.mCardUser.Controls.Add(this.pictureBoxPhoto);
            this.mCardUser.Controls.Add(this.mLabelPhNumb);
            this.mCardUser.Controls.Add(this.mLabelAddress);
            this.mCardUser.Controls.Add(this.mLabelSurname);
            this.mCardUser.Controls.Add(this.mLabelName);
            this.mCardUser.Depth = 0;
            this.mCardUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mCardUser.Location = new System.Drawing.Point(10, 14);
            this.mCardUser.Margin = new System.Windows.Forms.Padding(14);
            this.mCardUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.mCardUser.Name = "mCardUser";
            this.mCardUser.Padding = new System.Windows.Forms.Padding(14);
            this.mCardUser.Size = new System.Drawing.Size(368, 157);
            this.mCardUser.TabIndex = 0;
            // 
            // mLabelMail
            // 
            this.mLabelMail.AutoSize = true;
            this.mLabelMail.Depth = 0;
            this.mLabelMail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelMail.Location = new System.Drawing.Point(17, 120);
            this.mLabelMail.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelMail.Name = "mLabelMail";
            this.mLabelMail.Size = new System.Drawing.Size(85, 19);
            this.mLabelMail.TabIndex = 4;
            this.mLabelMail.Text = "mLabelMail";
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(255, 12);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(96, 132);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 6;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // mLabelPhNumb
            // 
            this.mLabelPhNumb.AutoSize = true;
            this.mLabelPhNumb.Depth = 0;
            this.mLabelPhNumb.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelPhNumb.Location = new System.Drawing.Point(17, 93);
            this.mLabelPhNumb.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelPhNumb.Name = "mLabelPhNumb";
            this.mLabelPhNumb.Size = new System.Drawing.Size(116, 19);
            this.mLabelPhNumb.TabIndex = 3;
            this.mLabelPhNumb.Text = "mLabelPhNumb";
            // 
            // mLabelAddress
            // 
            this.mLabelAddress.AutoSize = true;
            this.mLabelAddress.Depth = 0;
            this.mLabelAddress.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelAddress.Location = new System.Drawing.Point(17, 66);
            this.mLabelAddress.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelAddress.Name = "mLabelAddress";
            this.mLabelAddress.Size = new System.Drawing.Size(111, 19);
            this.mLabelAddress.TabIndex = 2;
            this.mLabelAddress.Text = "mLabelAddress";
            // 
            // mLabelSurname
            // 
            this.mLabelSurname.AutoSize = true;
            this.mLabelSurname.Depth = 0;
            this.mLabelSurname.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelSurname.Location = new System.Drawing.Point(17, 39);
            this.mLabelSurname.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelSurname.Name = "mLabelSurname";
            this.mLabelSurname.Size = new System.Drawing.Size(118, 19);
            this.mLabelSurname.TabIndex = 1;
            this.mLabelSurname.Text = "mLabelSurname";
            // 
            // mLabelName
            // 
            this.mLabelName.AutoSize = true;
            this.mLabelName.Depth = 0;
            this.mLabelName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelName.Location = new System.Drawing.Point(17, 12);
            this.mLabelName.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelName.Name = "mLabelName";
            this.mLabelName.Size = new System.Drawing.Size(96, 19);
            this.mLabelName.TabIndex = 0;
            this.mLabelName.Text = "mLabelName";
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.listViewRequestedTasks);
            this.tabTasks.Controls.Add(this.mLabel2);
            this.tabTasks.Controls.Add(this.listViewDoneTasks);
            this.tabTasks.Controls.Add(this.mLabel1);
            this.tabTasks.Location = new System.Drawing.Point(4, 22);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabTasks.Size = new System.Drawing.Size(378, 456);
            this.tabTasks.TabIndex = 1;
            this.tabTasks.Text = "TASK";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // listViewRequestedTasks
            // 
            this.listViewRequestedTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRid,
            this.colRacceptor,
            this.colRhours});
            this.listViewRequestedTasks.FullRowSelect = true;
            this.listViewRequestedTasks.HideSelection = false;
            this.listViewRequestedTasks.Location = new System.Drawing.Point(10, 244);
            this.listViewRequestedTasks.Name = "listViewRequestedTasks";
            this.listViewRequestedTasks.Size = new System.Drawing.Size(368, 168);
            this.listViewRequestedTasks.TabIndex = 3;
            this.listViewRequestedTasks.UseCompatibleStateImageBehavior = false;
            this.listViewRequestedTasks.View = System.Windows.Forms.View.Details;
            // 
            // colRid
            // 
            this.colRid.Text = "ID";
            // 
            // colRacceptor
            // 
            this.colRacceptor.Text = "ACCETTANTE";
            // 
            // colRhours
            // 
            this.colRhours.Text = "ORE";
            // 
            // mLabel2
            // 
            this.mLabel2.AutoSize = true;
            this.mLabel2.Depth = 0;
            this.mLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel2.Location = new System.Drawing.Point(10, 222);
            this.mLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(99, 19);
            this.mLabel2.TabIndex = 2;
            this.mLabel2.Text = "Task richieste";
            // 
            // listViewDoneTasks
            // 
            this.listViewDoneTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAid,
            this.colArequester,
            this.colAhours});
            this.listViewDoneTasks.FullRowSelect = true;
            this.listViewDoneTasks.HideSelection = false;
            this.listViewDoneTasks.Location = new System.Drawing.Point(10, 34);
            this.listViewDoneTasks.Name = "listViewDoneTasks";
            this.listViewDoneTasks.Size = new System.Drawing.Size(368, 168);
            this.listViewDoneTasks.TabIndex = 1;
            this.listViewDoneTasks.UseCompatibleStateImageBehavior = false;
            this.listViewDoneTasks.View = System.Windows.Forms.View.Details;
            // 
            // colAid
            // 
            this.colAid.Text = "ID";
            // 
            // colArequester
            // 
            this.colArequester.Text = "RICHIEDENTE";
            // 
            // colAhours
            // 
            this.colAhours.Text = "ORE";
            // 
            // mLabel1
            // 
            this.mLabel1.AutoSize = true;
            this.mLabel1.Depth = 0;
            this.mLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel1.Location = new System.Drawing.Point(10, 12);
            this.mLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(73, 19);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "Task fatte";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(10, 331);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(96, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Lavori offerti:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(211, 331);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(97, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Zone coperte:";
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 549);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "UserDetails";
            this.Text = "UserDetails";
            this.materialTabControl1.ResumeLayout(false);
            this.tabInfoUser.ResumeLayout(false);
            this.tabInfoUser.PerformLayout();
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.mCardUser.ResumeLayout(false);
            this.mCardUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.tabTasks.ResumeLayout(false);
            this.tabTasks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabInfoUser;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.Label labelDeltaHours;
        private MaterialSkin.Controls.MaterialLabel mLabelRecievedHours;
        private MaterialSkin.Controls.MaterialLabel mLabelDoneHours;
        private MaterialSkin.Controls.MaterialCard mCardUser;
        private MaterialSkin.Controls.MaterialLabel mLabelMail;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private MaterialSkin.Controls.MaterialLabel mLabelPhNumb;
        private MaterialSkin.Controls.MaterialLabel mLabelAddress;
        private MaterialSkin.Controls.MaterialLabel mLabelSurname;
        private MaterialSkin.Controls.MaterialLabel mLabelName;
        private System.Windows.Forms.TabPage tabTasks;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 mMultiLineTextBoxOfferedJobs;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 mMultiLineTextBoxDistricts;
        private System.Windows.Forms.ListView listViewRequestedTasks;
        private MaterialSkin.Controls.MaterialLabel mLabel2;
        private System.Windows.Forms.ListView listViewDoneTasks;
        private MaterialSkin.Controls.MaterialLabel mLabel1;
        private System.Windows.Forms.ColumnHeader colAid;
        private System.Windows.Forms.ColumnHeader colArequester;
        private System.Windows.Forms.ColumnHeader colAhours;
        private System.Windows.Forms.ColumnHeader colRid;
        private System.Windows.Forms.ColumnHeader colRacceptor;
        private System.Windows.Forms.ColumnHeader colRhours;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private System.Windows.Forms.Label labelAverageStars;
        private MaterialSkin.Controls.MaterialLabel mLabelTotalStars;
        private MaterialSkin.Controls.MaterialLabel mLabelNumbTsk;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}