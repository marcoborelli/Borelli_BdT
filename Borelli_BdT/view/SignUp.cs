﻿using System;
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

        public enum FormState {
            SignUp,
            Confirmation,
        }

        public EntityUser CurrentUser {
            get {
                EntityUser e = new EntityUser {
                    Field1 = mTextBoxUsername.Text,
                    Field2 = mTextBoxPasswd.Text,
                    Field3 = GetListFromCheckedListBox(mCheckLBoxJobs, mTextBoxOtherJob),
                    Field4 = GetListFromCheckedListBox(mCheckLBoxDistricts, mTextBoxOtherDistr),
                    Field12 = Presenter.GetLevel(mSwitchSecretary.Checked),
                    Field13 = CurrentData,
                };
                return e;
            }
            set {
                mTextBoxUsername.Text = value.Field1;
                mTextBoxPasswd.Text = value.Field2;
                SetCheckedIndexFromList(mCheckLBoxJobs, mTextBoxOtherJob, value.Field3);
                SetCheckedIndexFromList(mCheckLBoxDistricts, mTextBoxOtherDistr, value.Field4);
                mSwitchSecretary.Checked = Presenter.IsSecretary(value);
                CurrentData = value.Field13;
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
        public FormState FState { get; private set; }
        private SignUpPresenter Presenter { get; set; }

        public SignUp(EntityUser e) {
            InitializeComponent();
            FormManager.AddForm(this);

            Presenter = new SignUpPresenter(this);
            mButtonAction.Click += new EventHandler(Presenter.OnActionButton);
            mButtonDelete.Click += new EventHandler(Presenter.OnDeleteAccount);
            mButtonSaveChanges.Click += new EventHandler(Presenter.OnSaveChanges);

            CurrentUser = e;

            FState = FormState.Confirmation;
            SetForm();
        }
        public SignUp(string username, string passwd) {
            InitializeComponent();
            FormManager.AddForm(this);

            Presenter = new SignUpPresenter(this);
            mButtonAction.Click += new EventHandler(Presenter.OnActionButton);

            mTextBoxUsername.Text = username;
            mTextBoxPasswd.Text = passwd;

            FState = FormState.SignUp;
            SetForm();
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



        public void CloseForm() {
            this.Close();
        }

        public bool IsThereAnImage() {
            return pictureBoxPhoto.Image != null;
        }

        public void SaveProfilePicture(string path) {
            pictureBoxPhoto.Image.Save($"{path}", ImageFormat.Jpeg);
        }

        public void Error(string errorText) {
            MessageBox.Show($"{errorText}");
        }

        public void SuccessRegistration(string text) {
            MessageBox.Show($"{text}");
            this.Close();
        }

        public void UserIsAlredyInUse(string text) {
            MessageBox.Show($"{text}");
            mTextBoxUsername.Text = String.Empty;
        }

        public void LoadDistricts(List<string> items) {
            if (items != null) {
                for (int i = 0; i < items.Count; i++) {
                    mComboBoxHDistr.Items.Add(items[i]);
                    mCheckLBoxDistricts.Items.Add(items[i]);
                }
                mComboBoxHDistr.Text = mComboBoxHDistr.Items[0].ToString();
            }

        }

        public void LoadJobs(List<string> items) {
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


            List<string> otherValue = new List<string>(tb.Text.Split(';'));
            if (!String.IsNullOrWhiteSpace(tb.Text)) {
                for (int i = 0; i < otherValue.Count; i++) {
                    otherValue[i] = otherValue[i].Trim().ToUpper();
                }

                selectedItems.AddRange(otherValue);
            }


            return selectedItems;
        }
        private void SetCheckedIndexFromList(MaterialCheckedListBox clb, MaterialTextBox tb, List<string> checkedItems) {
            for (int i = 0; i < clb.Items.Count; i++) {
                clb.Items[i].Checked = checkedItems.Contains(clb.Items[i].Text);
            }

            //creao una lista uguale a quella di partenza cui tolgo tutti gli elementi già presenti nella checkedListBox così mi restano i lavori "nuovi"
            List<string> support = new List<string>();
            support.AddRange(checkedItems);

            for (int i = 0; i < clb.Items.Count; i++) {
                support.Remove(clb.Items[i].Text);
            }

            tb.Text = String.Join("; ", support);
        }

        private void SetForm() {
            switch (FState) {
                case FormState.SignUp:
                    pictureBoxPhoto.AllowDrop = true;
                    mButtonDelete.Visible = mButtonSaveChanges.Visible = mSwitchSecretary.Visible = false;
                    mButtonLoadImage.Visible = true; //faccio cosi' perche' senno' si bugga visualmente

                    mButtonAction.Text = "CREA ACCOUNT";
                    break;
                case FormState.Confirmation: //non devo poter modificare nessun campo tranne lavori e quartieri in cui lavora
                    pictureBoxPhoto.AllowDrop = false;
                    mTextBoxPasswd.Visible = false;
                    mTextBoxUsername.Enabled = mTextBoxName.Enabled = mTextBoxSurname.Enabled = mTextBoxPhNumb.Enabled =
                        mTextBoxMail.Enabled = mTextBoxAddr.Enabled = false;
                    mComboBoxHDistr.Enabled = dTimePickerBorn.Enabled = false;

                    mButtonAction.Text = "CONFERMA ACCOUNT";

                    pictureBoxPhoto.ImageLocation = Parameters.GetCompleteImagePath(CurrentUser.Field1);
                    pictureBoxPhoto.BorderStyle = BorderStyle.None;

                    break;
            }
        }
    }
}
