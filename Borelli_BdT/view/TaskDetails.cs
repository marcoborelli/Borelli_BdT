﻿using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Borelli_BdT.presenter;
using Borelli_BdT.utilities;

namespace Borelli_BdT.view {
    public partial class TaskDetails : MaterialForm {
        public enum FormState {
            Viewer,
            AcceptorModify,
            RequesterModify,
            AcceptTask,
            ValutateTask,
        }
        /* VIEWER: si entra cosi' o quando la task e' finita o quando non si e' ne' il richiedente ne' l'accettante.
         * ACCEPTOR_MODIFY: si entra cosi' quando l'accettante ha accettato ma il richiedente non ha ancora chiuso. L'accettante puo' rifiutare la task.
         * REQUESTER_MODIFY: si entra in questo modo quando la task e' solo ancora in fase di richiesta. Il richiedente puo' modificare la descrizione.
         * ACCEPT_TASK: si ha quando la task e' senza accettante, quindi chiunque puo' accettarla.
         * VALUTATE_TASK: si ha questo caso quando la task e' stata accettata, ad entrare e' il richiedente, e manca solo che sia valutata la prestazione dell'accettante */


        public EntityTask CurrentTask {
            get {
                EntityTask e = new EntityTask {
                    Field1 = this.Text,
                    Field2 = mMultiLineTextBoxCaption.Text,
                    Field3 = mTextBoxRequester.Text,
                    Field4 = mTextBoxAcceptor.Text,
                    Field5 = dTimePickerRequest.Text,
                    Field6 = dTimePickerAccepted.Text,
                    Field7 = dTimePickerStarted.Text,
                    Field8 = dTimePickerEnded.Text,
                    Field9 = new TimeSpan(int.Parse(textBoxHours.Text), int.Parse(textBoxMinutes.Text), 0).ToString(),
                    Field10 = mTextBoxStars.Text,
                    Field11 = mTextBoxJob.Text,
                   // Field12 = this.Text.Split(':')[1].Trim()
                };
                return e;
            }
            set {
                this.Text = value.Field1;
                mMultiLineTextBoxCaption.Text = value.Field2;
                mTextBoxRequester.Text = value.Field3;
                mTextBoxAcceptor.Text = value.Field4;
                dTimePickerRequest.Text = value.Field5;

                if (DateTime.Parse(value.Field6) != DateTime.MinValue)
                    dTimePickerAccepted.Text = value.Field6;
                else {
                    dTimePickerAccepted.Format = DateTimePickerFormat.Custom;
                    dTimePickerAccepted.CustomFormat = "N.A";
                }

                if (DateTime.Parse(value.Field7) != DateTime.MinValue) {
                    dTimePickerStarted.Text = value.Field7;
                    dTimePickerEnded.Text = value.Field8;
                } else {
                    dTimePickerStarted.Format = dTimePickerEnded.Format = DateTimePickerFormat.Custom;
                    dTimePickerStarted.CustomFormat = dTimePickerEnded.CustomFormat = "N.A";
                }

                textBoxHours.Text = $"{TimeSpan.Parse(value.Field9).Hours}";
                textBoxMinutes.Text = $"{TimeSpan.Parse(value.Field9).Minutes}";

                mTextBoxStars.Text = value.Field10;
                mTextBoxJob.Text = value.Field11;
                //this.Text += $": {value.Field12}";
            }
        }
        //TODO: private TaskDetailsPresenter Presenter { get; set; }
        public FormState State { get; private set; }

        public TaskDetails(string taskId, EntityUser e) {
            InitializeComponent();
            FormManager.AddForm(this);

            //TODO
            /*Presenter = new TaskDetailsPresenter(this, taskId, e);
            mButtonCancel.Click += new EventHandler(Presenter.OnCancelButton);
            mButtonAction.Click += new EventHandler(Presenter.OnActionButton);

            State = TaskDetailsPresenter.GetFormState(taskId, e);
            Presenter.SetForm();*/
        }



        public void ShowErrorMessge(string error) {
            MessageBox.Show($"{error}");
        }



        public void SetActionButton(string text) {
            mButtonAction.Text = text;
        }

        public void DisableAll() {
            DisableEndTaskFields();
            DisableRequestTaskField();
        }

        public void DisableRequestTaskField() {
            mMultiLineTextBoxCaption.Enabled = false;
        }

        public void DisableEndTaskFields() {
            mTextBoxStars.Enabled = dTimePickerStarted.Enabled = dTimePickerEnded.Enabled = textBoxHours.Enabled = textBoxMinutes.Enabled = false;
        }

        public void HideAllButtons() {
            mButtonAction.Visible = mButtonCancel.Visible = false;
        }



        //perche' all'inizio ho messo formato "N.A" per stampare a video che non e' presente alcun valore quindi poi devo ripristinare il formato originale
        private void dTimePickerStarted_ValueChanged(object sender, EventArgs e) {
            dTimePickerStarted.CustomFormat = "MM/dd/yyyy";
            dTimePickerStarted.Format = DateTimePickerFormat.Long;
        }

        private void dTimePickerEnded_ValueChanged(object sender, EventArgs e) {
            dTimePickerEnded.CustomFormat = "MM/dd/yyyy";
            dTimePickerEnded.Format = DateTimePickerFormat.Long;
        }
    }
}