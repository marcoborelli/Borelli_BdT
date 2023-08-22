namespace Borelli_BdT.view {
    partial class ItemsEditor {
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
            this.mListBox = new MaterialSkin.Controls.MaterialListBox();
            this.mButtonAdd = new MaterialSkin.Controls.MaterialButton();
            this.mTextBoxNewItem = new MaterialSkin.Controls.MaterialTextBox();
            this.mButtonSaveChanges = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // mListBox
            // 
            this.mListBox.BackColor = System.Drawing.Color.White;
            this.mListBox.BorderColor = System.Drawing.Color.LightGray;
            this.mListBox.Depth = 0;
            this.mListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mListBox.Location = new System.Drawing.Point(15, 27);
            this.mListBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.mListBox.Name = "mListBox";
            this.mListBox.SelectedIndex = -1;
            this.mListBox.SelectedItem = null;
            this.mListBox.Size = new System.Drawing.Size(292, 515);
            this.mListBox.TabIndex = 0;
            // 
            // mButtonAdd
            // 
            this.mButtonAdd.AutoSize = false;
            this.mButtonAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButtonAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButtonAdd.Depth = 0;
            this.mButtonAdd.HighEmphasis = true;
            this.mButtonAdd.Icon = null;
            this.mButtonAdd.Location = new System.Drawing.Point(314, 86);
            this.mButtonAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButtonAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButtonAdd.Name = "mButtonAdd";
            this.mButtonAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mButtonAdd.Size = new System.Drawing.Size(158, 36);
            this.mButtonAdd.TabIndex = 1;
            this.mButtonAdd.Text = "AGGIUNGI";
            this.mButtonAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButtonAdd.UseAccentColor = false;
            this.mButtonAdd.UseVisualStyleBackColor = true;
            // 
            // mTextBoxNewItem
            // 
            this.mTextBoxNewItem.AnimateReadOnly = false;
            this.mTextBoxNewItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mTextBoxNewItem.Depth = 0;
            this.mTextBoxNewItem.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTextBoxNewItem.Hint = "Nuovo valore";
            this.mTextBoxNewItem.LeadingIcon = null;
            this.mTextBoxNewItem.Location = new System.Drawing.Point(313, 27);
            this.mTextBoxNewItem.MaxLength = 50;
            this.mTextBoxNewItem.MouseState = MaterialSkin.MouseState.OUT;
            this.mTextBoxNewItem.Multiline = false;
            this.mTextBoxNewItem.Name = "mTextBoxNewItem";
            this.mTextBoxNewItem.Size = new System.Drawing.Size(159, 50);
            this.mTextBoxNewItem.TabIndex = 2;
            this.mTextBoxNewItem.Text = "";
            this.mTextBoxNewItem.TrailingIcon = null;
            // 
            // mButtonSaveChanges
            // 
            this.mButtonSaveChanges.AutoSize = false;
            this.mButtonSaveChanges.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButtonSaveChanges.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButtonSaveChanges.Depth = 0;
            this.mButtonSaveChanges.HighEmphasis = true;
            this.mButtonSaveChanges.Icon = null;
            this.mButtonSaveChanges.Location = new System.Drawing.Point(314, 506);
            this.mButtonSaveChanges.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButtonSaveChanges.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButtonSaveChanges.Name = "mButtonSaveChanges";
            this.mButtonSaveChanges.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mButtonSaveChanges.Size = new System.Drawing.Size(158, 36);
            this.mButtonSaveChanges.TabIndex = 3;
            this.mButtonSaveChanges.Text = "SALVA MODIFICHE";
            this.mButtonSaveChanges.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButtonSaveChanges.UseAccentColor = false;
            this.mButtonSaveChanges.UseVisualStyleBackColor = true;
            // 
            // ItemsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 554);
            this.Controls.Add(this.mButtonSaveChanges);
            this.Controls.Add(this.mTextBoxNewItem);
            this.Controls.Add(this.mButtonAdd);
            this.Controls.Add(this.mListBox);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "ItemsEditor";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "ItemsEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialListBox mListBox;
        private MaterialSkin.Controls.MaterialButton mButtonAdd;
        private MaterialSkin.Controls.MaterialTextBox mTextBoxNewItem;
        private MaterialSkin.Controls.MaterialButton mButtonSaveChanges;
    }
}