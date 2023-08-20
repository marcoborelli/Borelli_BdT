using System;
using Borelli_BdT.view;
using Borelli_BdT.utilities;
using Borelli_BdT.model;

namespace Borelli_BdT.presenter {
    public class SignUpPresenter {
        private SignUp _view;

        public SignUpPresenter(SignUp view) {
            View = view;

            View.AddDistricts(Districts.Zones);
            View.AddJobs(Jobs.Works);
        }

        private SignUp View {
            get => _view;
            set => _view = (value != null) ? value : throw new Exception("Inserire un attributo view valido");
        }

        public void OnCreateAccount(object sender, EventArgs e) {
            EntityUser tmp = View.CurrentUser;

            try {
                User u = new User(EntityCustomerMasterData.GetCustomerMasterData(tmp.Field11), tmp.Field1, tmp.Field2, tmp.Field3, tmp.Field4, RegContext.Registration);
                UsersList.AddUser(u);

                UsersList.WriteJsonFile();

                if (View.IsThereAnImage()) {
                    FileManager.CheckPicturesFolder(Parameters.DPPictures);
                    View.SaveProfilePicture($"{Parameters.DPPictures}/{u.Nickname}");
                }

                View.SuccessRegistration("La registrazione è stata effettuata con successo, ora attendi che un membro della segreteria la accetti");
            } catch (Exception ex) {
                View.Error(ex.ToString());
            }

        }

        public void OnCloseButton(object sender, EventArgs e) {
            View.CloseForm();
        }
    }
}
