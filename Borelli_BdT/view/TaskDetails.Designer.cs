namespace Borelli_BdT.view {
    partial class TaskDetails {
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
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.mTextBoxRequester = new MaterialSkin.Controls.MaterialTextBox();
            this.mTextBoxAcceptor = new MaterialSkin.Controls.MaterialTextBox();
            this.dTimePickerRequest = new System.Windows.Forms.DateTimePicker();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.mLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.mLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dTimePickerAccepted = new System.Windows.Forms.DateTimePicker();
            this.mLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.dTimePickerStarted = new System.Windows.Forms.DateTimePicker();
            this.mLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.dTimePickerEnded = new System.Windows.Forms.DateTimePicker();
            this.mTextBoxJob = new MaterialSkin.Controls.MaterialTextBox();
            this.mTextBoxStars = new MaterialSkin.Controls.MaterialTextBox();
            this.mButtonAction = new MaterialSkin.Controls.MaterialButton();
            this.mButtonCancel = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxHours = new System.Windows.Forms.TextBox();
            this.mLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxMinutes = new System.Windows.Forms.TextBox();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.mMultiLineTextBoxCaption = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.materialCard1.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.mTextBoxAcceptor);
            this.materialCard1.Controls.Add(this.mTextBoxRequester);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(14, 75);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(196, 141);
            this.materialCard1.TabIndex = 0;
            // 
            // mTextBoxRequester
            // 
            this.mTextBoxRequester.AnimateReadOnly = false;
            this.mTextBoxRequester.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mTextBoxRequester.Depth = 0;
            this.mTextBoxRequester.Enabled = false;
            this.mTextBoxRequester.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTextBoxRequester.Hint = "Richiedente";
            this.mTextBoxRequester.LeadingIcon = null;
            this.mTextBoxRequester.Location = new System.Drawing.Point(17, 17);
            this.mTextBoxRequester.MaxLength = 50;
            this.mTextBoxRequester.MouseState = MaterialSkin.MouseState.OUT;
            this.mTextBoxRequester.Multiline = false;
            this.mTextBoxRequester.Name = "mTextBoxRequester";
            this.mTextBoxRequester.Size = new System.Drawing.Size(162, 50);
            this.mTextBoxRequester.TabIndex = 0;
            this.mTextBoxRequester.Text = "";
            this.mTextBoxRequester.TrailingIcon = null;
            // 
            // mTextBoxAcceptor
            // 
            this.mTextBoxAcceptor.AnimateReadOnly = false;
            this.mTextBoxAcceptor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mTextBoxAcceptor.Depth = 0;
            this.mTextBoxAcceptor.Enabled = false;
            this.mTextBoxAcceptor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTextBoxAcceptor.Hint = "Accettante";
            this.mTextBoxAcceptor.LeadingIcon = null;
            this.mTextBoxAcceptor.Location = new System.Drawing.Point(17, 74);
            this.mTextBoxAcceptor.MaxLength = 50;
            this.mTextBoxAcceptor.MouseState = MaterialSkin.MouseState.OUT;
            this.mTextBoxAcceptor.Multiline = false;
            this.mTextBoxAcceptor.Name = "mTextBoxAcceptor";
            this.mTextBoxAcceptor.Size = new System.Drawing.Size(162, 50);
            this.mTextBoxAcceptor.TabIndex = 1;
            this.mTextBoxAcceptor.Text = "";
            this.mTextBoxAcceptor.TrailingIcon = null;
            // 
            // dTimePickerRequest
            // 
            this.dTimePickerRequest.Enabled = false;
            this.dTimePickerRequest.Location = new System.Drawing.Point(17, 39);
            this.dTimePickerRequest.Name = "dTimePickerRequest";
            this.dTimePickerRequest.Size = new System.Drawing.Size(162, 20);
            this.dTimePickerRequest.TabIndex = 1;
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.materialLabel1);
            this.materialCard2.Controls.Add(this.textBoxMinutes);
            this.materialCard2.Controls.Add(this.mLabel5);
            this.materialCard2.Controls.Add(this.textBoxHours);
            this.materialCard2.Controls.Add(this.materialLabel2);
            this.materialCard2.Controls.Add(this.mLabel4);
            this.materialCard2.Controls.Add(this.dTimePickerEnded);
            this.materialCard2.Controls.Add(this.mLabel3);
            this.materialCard2.Controls.Add(this.dTimePickerStarted);
            this.materialCard2.Controls.Add(this.mLabel2);
            this.materialCard2.Controls.Add(this.dTimePickerAccepted);
            this.materialCard2.Controls.Add(this.mLabel1);
            this.materialCard2.Controls.Add(this.dTimePickerRequest);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(221, 75);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(196, 294);
            this.materialCard2.TabIndex = 2;
            // 
            // mLabel1
            // 
            this.mLabel1.AutoSize = true;
            this.mLabel1.Depth = 0;
            this.mLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel1.Location = new System.Drawing.Point(17, 17);
            this.mLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(103, 19);
            this.mLabel1.TabIndex = 2;
            this.mLabel1.Text = "Data richiesta:";
            // 
            // mLabel2
            // 
            this.mLabel2.AutoSize = true;
            this.mLabel2.Depth = 0;
            this.mLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel2.Location = new System.Drawing.Point(17, 72);
            this.mLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(146, 19);
            this.mLabel2.TabIndex = 4;
            this.mLabel2.Text = "Data presa in carico:";
            // 
            // dTimePickerAccepted
            // 
            this.dTimePickerAccepted.Enabled = false;
            this.dTimePickerAccepted.Location = new System.Drawing.Point(17, 94);
            this.dTimePickerAccepted.Name = "dTimePickerAccepted";
            this.dTimePickerAccepted.Size = new System.Drawing.Size(162, 20);
            this.dTimePickerAccepted.TabIndex = 3;
            // 
            // mLabel3
            // 
            this.mLabel3.AutoSize = true;
            this.mLabel3.Depth = 0;
            this.mLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel3.Location = new System.Drawing.Point(17, 131);
            this.mLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(81, 19);
            this.mLabel3.TabIndex = 6;
            this.mLabel3.Text = "Data inizio:";
            // 
            // dTimePickerStarted
            // 
            this.dTimePickerStarted.Location = new System.Drawing.Point(17, 153);
            this.dTimePickerStarted.Name = "dTimePickerStarted";
            this.dTimePickerStarted.Size = new System.Drawing.Size(162, 20);
            this.dTimePickerStarted.TabIndex = 5;
            this.dTimePickerStarted.ValueChanged += new System.EventHandler(this.dTimePickerStarted_ValueChanged);
            // 
            // mLabel4
            // 
            this.mLabel4.AutoSize = true;
            this.mLabel4.Depth = 0;
            this.mLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel4.Location = new System.Drawing.Point(17, 186);
            this.mLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(70, 19);
            this.mLabel4.TabIndex = 8;
            this.mLabel4.Text = "Data fine:";
            // 
            // dTimePickerEnded
            // 
            this.dTimePickerEnded.Location = new System.Drawing.Point(17, 208);
            this.dTimePickerEnded.Name = "dTimePickerEnded";
            this.dTimePickerEnded.Size = new System.Drawing.Size(162, 20);
            this.dTimePickerEnded.TabIndex = 7;
            this.dTimePickerEnded.ValueChanged += new System.EventHandler(this.dTimePickerEnded_ValueChanged);
            // 
            // mTextBoxJob
            // 
            this.mTextBoxJob.AnimateReadOnly = false;
            this.mTextBoxJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mTextBoxJob.Depth = 0;
            this.mTextBoxJob.Enabled = false;
            this.mTextBoxJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTextBoxJob.Hint = "Lavoro";
            this.mTextBoxJob.LeadingIcon = null;
            this.mTextBoxJob.Location = new System.Drawing.Point(14, 17);
            this.mTextBoxJob.MaxLength = 50;
            this.mTextBoxJob.MouseState = MaterialSkin.MouseState.OUT;
            this.mTextBoxJob.Multiline = false;
            this.mTextBoxJob.Name = "mTextBoxJob";
            this.mTextBoxJob.Size = new System.Drawing.Size(162, 50);
            this.mTextBoxJob.TabIndex = 2;
            this.mTextBoxJob.Text = "";
            this.mTextBoxJob.TrailingIcon = null;
            // 
            // mTextBoxStars
            // 
            this.mTextBoxStars.AnimateReadOnly = false;
            this.mTextBoxStars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mTextBoxStars.Depth = 0;
            this.mTextBoxStars.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTextBoxStars.Hint = "Stelle";
            this.mTextBoxStars.LeadingIcon = null;
            this.mTextBoxStars.Location = new System.Drawing.Point(14, 74);
            this.mTextBoxStars.MaxLength = 50;
            this.mTextBoxStars.MouseState = MaterialSkin.MouseState.OUT;
            this.mTextBoxStars.Multiline = false;
            this.mTextBoxStars.Name = "mTextBoxStars";
            this.mTextBoxStars.Size = new System.Drawing.Size(162, 50);
            this.mTextBoxStars.TabIndex = 3;
            this.mTextBoxStars.Text = "";
            this.mTextBoxStars.TrailingIcon = null;
            // 
            // mButtonAction
            // 
            this.mButtonAction.AutoSize = false;
            this.mButtonAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButtonAction.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButtonAction.Depth = 0;
            this.mButtonAction.HighEmphasis = true;
            this.mButtonAction.Icon = null;
            this.mButtonAction.Location = new System.Drawing.Point(221, 505);
            this.mButtonAction.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButtonAction.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButtonAction.Name = "mButtonAction";
            this.mButtonAction.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mButtonAction.Size = new System.Drawing.Size(196, 58);
            this.mButtonAction.TabIndex = 6;
            this.mButtonAction.Text = "materialButton1";
            this.mButtonAction.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButtonAction.UseAccentColor = false;
            this.mButtonAction.UseVisualStyleBackColor = true;
            // 
            // mButtonCancel
            // 
            this.mButtonCancel.AutoSize = false;
            this.mButtonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButtonCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButtonCancel.Depth = 0;
            this.mButtonCancel.HighEmphasis = true;
            this.mButtonCancel.Icon = null;
            this.mButtonCancel.Location = new System.Drawing.Point(14, 505);
            this.mButtonCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButtonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButtonCancel.Name = "mButtonCancel";
            this.mButtonCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mButtonCancel.Size = new System.Drawing.Size(196, 58);
            this.mButtonCancel.TabIndex = 7;
            this.mButtonCancel.Text = "ANNULLA";
            this.mButtonCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButtonCancel.UseAccentColor = false;
            this.mButtonCancel.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(17, 241);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(62, 19);
            this.materialLabel2.TabIndex = 11;
            this.materialLabel2.Text = "Duarata:";
            // 
            // textBoxHours
            // 
            this.textBoxHours.Location = new System.Drawing.Point(17, 263);
            this.textBoxHours.Name = "textBoxHours";
            this.textBoxHours.Size = new System.Drawing.Size(30, 20);
            this.textBoxHours.TabIndex = 12;
            // 
            // mLabel5
            // 
            this.mLabel5.AutoSize = true;
            this.mLabel5.Depth = 0;
            this.mLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel5.Location = new System.Drawing.Point(53, 263);
            this.mLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.Size = new System.Drawing.Size(10, 19);
            this.mLabel5.TabIndex = 13;
            this.mLabel5.Text = "h";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(105, 262);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(15, 19);
            this.materialLabel1.TabIndex = 15;
            this.materialLabel1.Text = "m";
            // 
            // textBoxMinutes
            // 
            this.textBoxMinutes.Location = new System.Drawing.Point(69, 262);
            this.textBoxMinutes.Name = "textBoxMinutes";
            this.textBoxMinutes.Size = new System.Drawing.Size(30, 20);
            this.textBoxMinutes.TabIndex = 14;
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.mTextBoxStars);
            this.materialCard3.Controls.Add(this.mTextBoxJob);
            this.materialCard3.Depth = 0;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(14, 228);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard3.Size = new System.Drawing.Size(196, 141);
            this.materialCard3.TabIndex = 2;
            // 
            // mMultiLineTextBoxCaption
            // 
            this.mMultiLineTextBoxCaption.AnimateReadOnly = false;
            this.mMultiLineTextBoxCaption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mMultiLineTextBoxCaption.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mMultiLineTextBoxCaption.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mMultiLineTextBoxCaption.Depth = 0;
            this.mMultiLineTextBoxCaption.HideSelection = true;
            this.mMultiLineTextBoxCaption.Hint = "Descrizione";
            this.mMultiLineTextBoxCaption.Location = new System.Drawing.Point(14, 386);
            this.mMultiLineTextBoxCaption.MaxLength = 32767;
            this.mMultiLineTextBoxCaption.MouseState = MaterialSkin.MouseState.OUT;
            this.mMultiLineTextBoxCaption.Name = "mMultiLineTextBoxCaption";
            this.mMultiLineTextBoxCaption.PasswordChar = '\0';
            this.mMultiLineTextBoxCaption.ReadOnly = false;
            this.mMultiLineTextBoxCaption.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mMultiLineTextBoxCaption.SelectedText = "";
            this.mMultiLineTextBoxCaption.SelectionLength = 0;
            this.mMultiLineTextBoxCaption.SelectionStart = 0;
            this.mMultiLineTextBoxCaption.ShortcutsEnabled = true;
            this.mMultiLineTextBoxCaption.Size = new System.Drawing.Size(403, 110);
            this.mMultiLineTextBoxCaption.TabIndex = 8;
            this.mMultiLineTextBoxCaption.TabStop = false;
            this.mMultiLineTextBoxCaption.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mMultiLineTextBoxCaption.UseSystemPasswordChar = false;
            // 
            // TaskDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 585);
            this.Controls.Add(this.mMultiLineTextBoxCaption);
            this.Controls.Add(this.materialCard3);
            this.Controls.Add(this.mButtonCancel);
            this.Controls.Add(this.mButtonAction);
            this.Controls.Add(this.materialCard2);
            this.Controls.Add(this.materialCard1);
            this.Name = "TaskDetails";
            this.Text = "TaskDetails";
            this.materialCard1.ResumeLayout(false);
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.materialCard3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialTextBox mTextBoxAcceptor;
        private MaterialSkin.Controls.MaterialTextBox mTextBoxRequester;
        private System.Windows.Forms.DateTimePicker dTimePickerRequest;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialLabel mLabel4;
        private System.Windows.Forms.DateTimePicker dTimePickerEnded;
        private MaterialSkin.Controls.MaterialLabel mLabel3;
        private System.Windows.Forms.DateTimePicker dTimePickerStarted;
        private MaterialSkin.Controls.MaterialLabel mLabel2;
        private System.Windows.Forms.DateTimePicker dTimePickerAccepted;
        private MaterialSkin.Controls.MaterialLabel mLabel1;
        private MaterialSkin.Controls.MaterialTextBox mTextBoxJob;
        private MaterialSkin.Controls.MaterialTextBox mTextBoxStars;
        private MaterialSkin.Controls.MaterialButton mButtonAction;
        private MaterialSkin.Controls.MaterialButton mButtonCancel;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox textBoxMinutes;
        private MaterialSkin.Controls.MaterialLabel mLabel5;
        private System.Windows.Forms.TextBox textBoxHours;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 mMultiLineTextBoxCaption;
    }
}