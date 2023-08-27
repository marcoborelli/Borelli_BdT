namespace Borelli_BdT.view {
    partial class Login {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.mLabelLogin = new MaterialSkin.Controls.MaterialLabel();
            this.mTextBoxUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.mTextBoxPasswd = new MaterialSkin.Controls.MaterialTextBox();
            this.mButtonLogin = new MaterialSkin.Controls.MaterialButton();
            this.mButtonSignUp = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // mLabelLogin
            // 
            this.mLabelLogin.AutoSize = true;
            this.mLabelLogin.Depth = 0;
            this.mLabelLogin.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mLabelLogin.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.mLabelLogin.Location = new System.Drawing.Point(34, 38);
            this.mLabelLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelLogin.Name = "mLabelLogin";
            this.mLabelLogin.Size = new System.Drawing.Size(84, 41);
            this.mLabelLogin.TabIndex = 0;
            this.mLabelLogin.Text = "Login";
            // 
            // mTextBoxUsername
            // 
            this.mTextBoxUsername.AnimateReadOnly = false;
            this.mTextBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mTextBoxUsername.Depth = 0;
            this.mTextBoxUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTextBoxUsername.Hint = "Nickname";
            this.mTextBoxUsername.LeadingIcon = null;
            this.mTextBoxUsername.Location = new System.Drawing.Point(34, 132);
            this.mTextBoxUsername.MaxLength = 50;
            this.mTextBoxUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.mTextBoxUsername.Multiline = false;
            this.mTextBoxUsername.Name = "mTextBoxUsername";
            this.mTextBoxUsername.Size = new System.Drawing.Size(241, 50);
            this.mTextBoxUsername.TabIndex = 1;
            this.mTextBoxUsername.Text = "";
            this.mTextBoxUsername.TrailingIcon = null;
            this.mTextBoxUsername.Enter += new System.EventHandler(this.mTextBoxUsername_Enter);
            // 
            // mTextBoxPasswd
            // 
            this.mTextBoxPasswd.AnimateReadOnly = false;
            this.mTextBoxPasswd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mTextBoxPasswd.Depth = 0;
            this.mTextBoxPasswd.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTextBoxPasswd.Hint = "Password";
            this.mTextBoxPasswd.LeadingIcon = null;
            this.mTextBoxPasswd.Location = new System.Drawing.Point(34, 210);
            this.mTextBoxPasswd.MaxLength = 50;
            this.mTextBoxPasswd.MouseState = MaterialSkin.MouseState.OUT;
            this.mTextBoxPasswd.Multiline = false;
            this.mTextBoxPasswd.Name = "mTextBoxPasswd";
            this.mTextBoxPasswd.Password = true;
            this.mTextBoxPasswd.Size = new System.Drawing.Size(241, 50);
            this.mTextBoxPasswd.TabIndex = 2;
            this.mTextBoxPasswd.Text = "";
            this.mTextBoxPasswd.TrailingIcon = null;
            this.mTextBoxPasswd.Enter += new System.EventHandler(this.mTextBoxPasswd_Enter);
            // 
            // mButtonLogin
            // 
            this.mButtonLogin.AutoSize = false;
            this.mButtonLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButtonLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButtonLogin.Depth = 0;
            this.mButtonLogin.HighEmphasis = true;
            this.mButtonLogin.Icon = null;
            this.mButtonLogin.Location = new System.Drawing.Point(160, 293);
            this.mButtonLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButtonLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButtonLogin.Name = "mButtonLogin";
            this.mButtonLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mButtonLogin.Size = new System.Drawing.Size(115, 52);
            this.mButtonLogin.TabIndex = 3;
            this.mButtonLogin.Text = "LOGIN";
            this.mButtonLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButtonLogin.UseAccentColor = false;
            this.mButtonLogin.UseVisualStyleBackColor = true;
            // 
            // mButtonSignUp
            // 
            this.mButtonSignUp.AutoSize = false;
            this.mButtonSignUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButtonSignUp.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButtonSignUp.Depth = 0;
            this.mButtonSignUp.HighEmphasis = true;
            this.mButtonSignUp.Icon = null;
            this.mButtonSignUp.Location = new System.Drawing.Point(34, 293);
            this.mButtonSignUp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButtonSignUp.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButtonSignUp.Name = "mButtonSignUp";
            this.mButtonSignUp.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mButtonSignUp.Size = new System.Drawing.Size(115, 52);
            this.mButtonSignUp.TabIndex = 4;
            this.mButtonSignUp.Text = "REGISTRATI";
            this.mButtonSignUp.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButtonSignUp.UseAccentColor = false;
            this.mButtonSignUp.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 380);
            this.Controls.Add(this.mButtonSignUp);
            this.Controls.Add(this.mButtonLogin);
            this.Controls.Add(this.mTextBoxPasswd);
            this.Controls.Add(this.mTextBoxUsername);
            this.Controls.Add(this.mLabelLogin);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "BdT - 0.0.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel mLabelLogin;
        private MaterialSkin.Controls.MaterialTextBox mTextBoxPasswd;
        private MaterialSkin.Controls.MaterialButton mButtonLogin;
        private MaterialSkin.Controls.MaterialTextBox mTextBoxUsername;
        private MaterialSkin.Controls.MaterialButton mButtonSignUp;
    }
}

