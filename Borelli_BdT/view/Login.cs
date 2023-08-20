using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Borelli_BdT.presenter;
using Borelli_BdT.utilities;

namespace Borelli_BdT.view {
    public partial class Login : MaterialForm {
        //private SignUp SignUpForm { get; set; } TODO
        //private MainPage MainForm { get; set; } TODO
        public Login() {
            InitializeComponent();
            FormManager.Init();
            FormManager.AddForm(this);

            LoginPresenter p = new LoginPresenter(this);
            mButtonLogin.Click += new EventHandler(p.OnLogin);
            mButtonSignUp.Click += new EventHandler(p.OnSignUp);
        }

        public List<string> GetFieldsValue() {
            return new List<string> {
                mTextBoxUsername.Text,
                mTextBoxPasswd.Text
            };
        }

        public void NotValidUsername() {
            mTextBoxUsername.Text = mTextBoxPasswd.Text = "";
            MessageBox.Show("Inserire un nome utente esistente");
        }

        public void NotValidPassword() {
            mTextBoxPasswd.Text = "";
            MessageBox.Show("Password sbagliata");
        }

        public void UserIsNotYetConfirmed() {
            mTextBoxUsername.Text = mTextBoxPasswd.Text = "";
            MessageBox.Show("L'utente in questione è ancora in attesa di conferma da parte della segreteria");
        }

        public void DoLogin() { //TODO
            /*MainForm = new MainPage(mTextBoxUsername.Text); TODO
            this.Hide();
            MainForm.ShowDialog();
            this.Show();*/
        }

        public void ShowSignUpForm() { //TODO
            /*SignUpForm = new SignUp(mTextBoxUsername.Text, mTextBoxPasswd.Text);
            this.Hide();
            SignUpForm.ShowDialog();
            this.Show();*/
        }
    }
}
