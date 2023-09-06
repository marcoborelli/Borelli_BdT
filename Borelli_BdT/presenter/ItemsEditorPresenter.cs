using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Borelli_BdT.view;
using Borelli_BdT.model;

namespace Borelli_BdT.presenter {
    public class ItemsEditorPresenter {
        private ItemsEditor _view;
        private bool Modified { get; set; }
        private List<string> TmpList { get; set; }

        public ItemsEditorPresenter(ItemsEditor view) {
            View = view;
            Modified = false;
        }

        private ItemsEditor View {
            get => _view;
            set => _view = (value != null) ? value : throw new Exception("Inserire un attributo view valido");
        }



        public void OnAddButton(object sender, EventArgs e) {
            string newItem = View.GetNewItemText().Trim().ToUpper();

            try {
                switch (View.FormUse) {
                    case ItemsEditor.Use.Jobs:
                        if (!Jobs.IsJobValid(newItem) && !String.IsNullOrWhiteSpace(newItem)) {
                            TmpList.Add(newItem);
                        } else {
                            View.ShowError("Inserire un elemento valido e non già esistente");
                            return;
                        }

                        break;
                    case ItemsEditor.Use.Districts:
                        if (!Districts.IsDistrictValid(newItem) && !String.IsNullOrWhiteSpace(newItem)) {
                            TmpList.Add(newItem);
                        } else {
                            View.ShowError("Inserire un elemento valido e non già esistente");
                            return;
                        }

                        break;
                }
                LoadListBox();
                View.ResetTextBox();

                Modified = true;
            } catch (Exception ex) {
                View.ShowError(ex.Message);
            }
        }

        public void InitList() {
            switch (View.FormUse) {
                case ItemsEditor.Use.Districts:
                    TmpList = new List<string>(Districts.Zones);
                    break;
                case ItemsEditor.Use.Jobs:
                    TmpList = new List<string>(Jobs.Works);
                    break;
            }
        }

        public void FormClosing(object sender, FormClosingEventArgs e) {
            if (Modified) {
                if (View.NotSavedChanges("Ci sono modifiche non salvate. Desideri salvarle?")) {
                    SaveChanges();
                }
            }
        }

        public void LoadListBox() {
            Regex rxRicerca = new Regex(View.GetTextInSearchBar(), RegexOptions.IgnoreCase);

            List<string> filteredData = FilterList(TmpList, rxRicerca);
            View.LoadItemsInListBox(filteredData);
        }

        public void ReLoadLoadListBox(object sender, EventArgs e) {
            LoadListBox();
        }

        public void OnSaveChanges(object sender, EventArgs e) {
            SaveChanges();
            View.Close();
        }




        private List<string> FilterList(List<string> input, Regex rx) {
            List<string> outp = new List<string>();

            for (int i = 0; i < input.Count; i++) {
                if (rx.IsMatch(input[i])) {
                    outp.Add(input[i]);
                }
            }

            return outp;
        }

        private void SaveChanges() {
            switch (View.FormUse) {
                case ItemsEditor.Use.Jobs:
                    AddToMainList(TmpList, Jobs.Works);
                    Jobs.WriteJsonFile();
                    break;
                case ItemsEditor.Use.Districts:
                    AddToMainList(TmpList, Districts.Zones);
                    Districts.WriteJsonFile();
                    break;
            }

            Modified = false;
        }

        private void AddToMainList(List<string> tmpList, List<string> mainList) {
            List<string> missingElements = tmpList.Except(mainList).ToList();

            mainList.AddRange(missingElements);
        }
    }
}
