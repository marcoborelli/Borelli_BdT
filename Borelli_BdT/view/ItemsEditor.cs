using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Borelli_BdT.presenter;
using Borelli_BdT.utilities;

namespace Borelli_BdT.view {
    public partial class ItemsEditor : MaterialForm {
        public enum Use {
            Districts,
            Jobs,
        }

        public Use FormUse { get; private set; }
        public ItemsEditor(Use u) {
            //TODO: mettere anche rinomina di un lavoro e eliminazione
            InitializeComponent();
            FormManager.AddForm(this);


            FormUse = u;

            ItemsEditorPresenter p = new ItemsEditorPresenter(this);
            p.InitList();
            p.LoadListBox();

            textBoxSearch.TextChanged += new EventHandler(p.ReLoadLoadListBox);
            mButtonAdd.Click += new EventHandler(p.OnAddButton);
            mButtonSaveChanges.Click += new EventHandler(p.OnSaveChanges);
            FormClosing += new FormClosingEventHandler(p.FormClosing);
        }



        public void LoadItemsInListBox(List<string> items) {
            mListBox.Items.Clear();

            for (int i = 0; i < items.Count; i++) {
                mListBox.Items.Add(new MaterialListBoxItem(items[i]));
            }
        }

        public bool NotSavedChanges(string text) {
            DialogResult dr = MessageBox.Show($"{text}", "MODIFICHE NON SALVATE", MessageBoxButtons.YesNo);
            return (dr == DialogResult.Yes);
        }

        public string GetTextInSearchBar() {
            return textBoxSearch.Text;
        }
        public void ShowError(string error) {
            MessageBox.Show($"{error}");
            ResetTextBox();
        }

        public string GetNewItemText() {
            return mTextBoxNewItem.Text.Trim().ToUpper();
        }

        public void ResetTextBox() {
            mTextBoxNewItem.Text = String.Empty;
        }

        public void CloseForm() {
            this.Close();
        }
    }
}
