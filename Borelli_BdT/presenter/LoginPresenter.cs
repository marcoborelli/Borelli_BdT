using System;
using System.Collections.Generic;
using Borelli_BdT.model;
using Borelli_BdT.view;
using Borelli_BdT.utilities;

namespace Borelli_BdT.presenter {
    public class LoginPresenter {
        private Login _view;

        public LoginPresenter(Login view) {
            View = view;

            InitStaticClasses();
        }

        private Login View {
            get => _view;
            set => _view = (value != null) ? value : throw new Exception("Inserire un attributo view valido");
        }


        public void OnLogin(object sender, EventArgs e) {
            List<string> fields = View.GetFieldsValue();
            int index = UsersList.GetUserIndex(fields[0]);

            if (index == -1) {
                View.NotValidUsername();
            } else {
                if (UsersList.Users[index].IsPasswordCorrect(fields[1])) {
                    if (UsersList.Users[index].State == RegContext.Confirmed)
                        View.DoLogin();
                    else
                        View.UserIsNotYetConfirmed();
                } else {
                    View.NotValidPassword();
                }

            }

        }

        public void OnSignUp(object sender, EventArgs e) {
            View.ShowSignUpForm();
        }

        private void InitStaticClasses() {
            Parameters.Init();

            Districts.Init();
            Jobs.Init();
            UsersList.Init();
            TasksList.Init();
        }
    }
}
