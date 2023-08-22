using System;
using Borelli_BdT.view;
using Borelli_BdT.utilities;
using Borelli_BdT.model;
using System.Windows.Forms;

namespace Borelli_BdT.presenter {
    public class SignUpPresenter {
        private SignUp _view;

        public SignUpPresenter(SignUp view) {
            View = view;

            View.LoadDistricts(Districts.Zones);
            View.LoadJobs(Jobs.Works);
        }

        private SignUp View {
            get => _view;
            set => _view = (value != null) ? value : throw new Exception("Inserire un attributo view valido");
        }

        public void OnCreateAccount(object sender, EventArgs e) {
            EntityUser tmp = View.CurrentUser;

            try {
                switch (View.FState) {
                    case SignUp.FormState.SignUp:

                        if (UsersList.IsUserValid(tmp.Field1)) {
                            View.UserIsAlredyInUse("Il nome utente scelto è già in uso, sceglierne uno diverso");
                            return;
                        }

                        User u = new User(EntityCustomerMasterData.GetCustomerMasterData(tmp.Field11), tmp.Field1, tmp.Field2, tmp.Field3, tmp.Field4, RegContext.Registration);
                        UsersList.AddUser(u);

                        if (View.IsThereAnImage()) {
                            FileManager.CheckFolder(Parameters.DPPictures);
                            View.SaveProfilePicture($"{Parameters.DPPictures}/{u.Nickname}");
                        }

                        View.SuccessRegistration("La registrazione è stata effettuata con successo, ora attendi che un membro della segreteria la accetti");

                        break;
                    case SignUp.FormState.Confirmation:

                        int index = UsersList.GetUserIndex(tmp.Field1);
                        User us = UsersList.GetUser(tmp.Field1);

                        UsersList.Users[index] = new User(us.Data, us.Nickname, us.Password, tmp.Field3, tmp.Field4, RegContext.Confirmed);
                        View.SuccessRegistration("La conferma dell'account è stata effettuata con successo");

                        break;
                }

                UsersList.WriteJsonFile();
                View.CloseForm();

            } catch (Exception ex) {
                View.Error(ex.Message);
            }

        }

        public void OnDeleteAccount(object sender, EventArgs e) {
            if (View.FState == SignUp.FormState.Confirmation) {
                EntityUser tmp = View.CurrentUser;

                UsersList.RemoveUser(tmp.Field1);
                UsersList.WriteJsonFile();

                View.CloseForm();
            }
        }

        public void OnSaveChanges(object sender, EventArgs e) { //per tenere da parte le modifiche fatte dal segretario che magari ci torna su dopo ma vuole salvare intanto
            if (View.FState == SignUp.FormState.Confirmation) {
                EntityUser tmp = View.CurrentUser;

                int index = UsersList.GetUserIndex(tmp.Field1);
                UsersList.Users[index] = new User(EntityCustomerMasterData.GetCustomerMasterData(tmp.Field11), tmp.Field1, tmp.Field2, tmp.Field3, tmp.Field4, RegContext.Registration);
                UsersList.WriteJsonFile();
            }
        }
    }
}
