using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MaterialSkin;
using MaterialSkin.Controls;
using Borelli_BdT.presenter;
using Borelli_BdT.utilities;

namespace Borelli_BdT.view {
    public partial class SignUp : MaterialForm {

        public EntityUser CurrentUser {
            get {
                EntityUser e = new EntityUser {
                    Field1 = mTextBoxUsername.Text,
                    Field2 = mTextBoxPasswd.Text,
                    Field3 = GetListFromCheckedListBox(mCheckLBoxJobs, mTextBoxOtherJob),
                    Field4 = GetListFromCheckedListBox(mCheckLBoxDistricts, mTextBoxOtherDistr),
                    Field11 = CurrentData,
                };
                return e;
            }
            set {
                mTextBoxUsername.Text = value.Field1;
                mTextBoxPasswd.Text = value.Field2;
                SetCheckedIndexFromList(mCheckLBoxJobs, value.Field3);
                SetCheckedIndexFromList(mCheckLBoxDistricts, value.Field4);
                CurrentData = value.Field11;
            }
        }
        public EntityCustomerMasterData CurrentData {
            get {
                EntityCustomerMasterData e = new EntityCustomerMasterData {
                    Field1 = mTextBoxName.Text,
                    Field2 = mTextBoxSurname.Text,
                    Field3 = mTextBoxPhNumb.Text,
                    Field4 = mTextBoxMail.Text,
                    Field5 = mTextBoxAddr.Text,
                    Field6 = mComboBoxHDistr.Text,
                    Field7 = dTimePickerBorn.Text
                };
                return e;
            }
            set {
                mTextBoxName.Text = value.Field1;
                mTextBoxSurname.Text = value.Field2;
                mTextBoxPhNumb.Text = value.Field3;
                mTextBoxMail.Text = value.Field4;
                mTextBoxAddr.Text = value.Field5;
                mComboBoxHDistr.Text = value.Field6;
                dTimePickerBorn.Text = value.Field7;
            }
        }


        public SignUp() : this(String.Empty, String.Empty) {
        }
        public SignUp(string username, string passwd) {
            InitializeComponent();
            FormManager.AddForm(this);

            pictureBoxPhoto.AllowDrop = true;

            SignUpPresenter p = new SignUpPresenter(this);
            mButtonCreateAccount.Click += new EventHandler(p.OnCreateAccount);
            mButtonDelete.Click += new EventHandler(p.OnCloseButton);

            mTextBoxUsername.Text = username;
            mTextBoxPasswd.Text = passwd;
        }

        private void mButtonLoadImage_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK) {
                pictureBoxPhoto.ImageLocation = ofd.FileName;
            }
        }

        private void pictureBoxPhoto_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy; // Set the effect to copy or move based on your requirement
            }
        }
        private void pictureBoxPhoto_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0) {
                Image image = Image.FromFile(files[0]); // Load the first image from the dropped files
                pictureBoxPhoto.Image = image; // Display the image in the PictureBox control
            }

            pictureBoxPhoto.BorderStyle = BorderStyle.None;
        }


        public bool IsThereAnImage() {
            return pictureBoxPhoto.Image != null;
        }

        public void SaveProfilePicture(string path) {
            pictureBoxPhoto.Image.Save($"{path}.jpg", ImageFormat.Jpeg);
        }

        public void Error(string errorText) {
            MessageBox.Show($"{errorText}");
        }

        public void SuccessRegistration(string text) {
            MessageBox.Show($"{text}");
        }

        public void CloseForm() {
            this.Close();
        }

        public void AddDistricts(List<string> items) {
            if (items != null) {
                for (int i = 0; i < items.Count; i++) {
                    mComboBoxHDistr.Items.Add(items[i]);
                    mCheckLBoxDistricts.Items.Add(items[i]);
                }
                mComboBoxHDistr.Text = mComboBoxHDistr.Items[0].ToString();
            }

        }

        public void AddJobs(List<string> items) {
            if (items != null) {
                for (int i = 0; i < items.Count; i++) {
                    mCheckLBoxJobs.Items.Add(items[i]);
                }
            }
        }

        private List<string> GetListFromCheckedListBox(MaterialCheckedListBox clb, MaterialTextBox tb) {
            List<string> selectedItems = new List<string>();

            for (int i = 0; i < clb.Items.Count; i++) {
                if (clb.Items[i].Checked)
                    selectedItems.Add(clb.Items[i].Text);
            }

            tb.Text = tb.Text.Trim().ToUpper();
            if (!String.IsNullOrWhiteSpace(tb.Text) && !selectedItems.Contains(tb.Text)) {
                selectedItems.Add(tb.Text.Trim().ToUpper());
            }


            return selectedItems;
        }
        private void SetCheckedIndexFromList(MaterialCheckedListBox clb, List<string> checkedItems) {
            for (int i = 0; i < clb.Items.Count; i++) {
                clb.Items[i].Checked = checkedItems.Contains(clb.Items[i].Text);
            }
        }
    }
}
