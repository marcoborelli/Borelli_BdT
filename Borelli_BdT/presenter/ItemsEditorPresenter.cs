using System;
using Borelli_BdT.view;
using Borelli_BdT.model;

namespace Borelli_BdT.presenter {
    public class ItemsEditorPresenter {
        private ItemsEditor _view;

        public ItemsEditorPresenter(ItemsEditor view) {
            View = view;
            LoadListBox();
        }

        private ItemsEditor View {
            get => _view;
            set => _view = (value != null) ? value : throw new Exception("Inserire un attributo view valido");
        }

        public void OnAddButton(object sender, EventArgs e) {
            string newItem = View.GetNewItemText();

            try {
                switch (View.FormUse) {
                    case ItemsEditor.Use.Jobs:
                        Jobs.AddJob(newItem);
                        break;
                    case ItemsEditor.Use.Districts:
                        Districts.AddDistrict(newItem);
                        break;
                }
                LoadListBox();
                View.ResetTextBox();
            } catch (Exception ex) {
                View.ShowError(ex.Message);
            }
        }

        public void SaveChanges(object sender, EventArgs e) {
            switch (View.FormUse) {
                case ItemsEditor.Use.Jobs:
                    Jobs.WriteJsonFile();
                    break;
                case ItemsEditor.Use.Districts:
                    Districts.WriteJsonFile();
                    break;
            }

            View.CloseForm();
        }

        private void LoadListBox() {
            switch (View.FormUse) {
                case ItemsEditor.Use.Jobs:
                    View.LoadItemsInListBox(Jobs.Works);
                    break;
                case ItemsEditor.Use.Districts:
                    View.LoadItemsInListBox(Districts.Zones);
                    break;
            }
        }
    }
}
