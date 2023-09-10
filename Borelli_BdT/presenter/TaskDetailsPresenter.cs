using System;
using Borelli_BdT.model;
using Borelli_BdT.view;

namespace Borelli_BdT.presenter {
    public class TaskDetailsPresenter {
        private TaskDetails _view;

        private User CurrentUser { get; set; }
        private Task CurrentTask { get; set; }

        public TaskDetailsPresenter(TaskDetails view, string taskId, EntityUser eu) { //TODO: controllare se ci sono altri modi per fare senza passarsi l'utente
            View = view;

            Task t = TasksList.GetTask(taskId);

            if (t == null) {
                throw new Exception("Errore caricamento task");
            }

            EntityTask et = EntityTask.GetEntity(t);
            View.CurrentTask = et;
            CurrentTask = t;

            CurrentUser = UsersList.GetUser(eu.Field1);
            if (CurrentUser == null) {
                throw new Exception("Errore caricamento user");
            }
        }

        private TaskDetails View {
            get => _view;
            set => _view = (value != null) ? value : throw new Exception("Inserire un attributo view valido");
        }



        public void OnCancelButton(object sender, EventArgs e) {
            View.Close();
        }
        public void OnActionButton(object sender, EventArgs e) {
            bool exception = false;
            Task backup = CurrentTask.Clone(); //perche' in caso mi inizi a mettere dei valori ma poi dia eccezione almeno cosi' ripristino il precedente stato

            switch (View.State) {
                case TaskDetails.FormState.AcceptorModify: //abbandono task
                    try {
                        CurrentUser.LeftTask(CurrentTask);
                    } catch (Exception ex) {
                        exception = true;
                        View.ShowErrorMessge(ex.Message);
                    }
                    break;
                case TaskDetails.FormState.RequesterModify:
                    try {
                        CurrentUser.ModifyTask(CurrentTask, View.CurrentTask.Field2);
                    } catch (Exception ex) {
                        exception = true;
                        View.ShowErrorMessge(ex.Message);
                    }
                    break;
                case TaskDetails.FormState.AcceptTask:
                    try {
                        CurrentUser.AcceptTask(CurrentTask);
                    } catch (Exception ex) {
                        exception = true;
                        View.ShowErrorMessge(ex.Message);
                    }
                    break;
                case TaskDetails.FormState.ValutateTask:
                    try {
                        EntityTask et = View.CurrentTask;

                        DateTime startTime = DateTime.Parse(et.Field7);
                        DateTime endTime = DateTime.Parse(et.Field8);
                        TimeSpan taskLength = TimeSpan.Parse(et.Field9);
                        float stars = float.Parse(et.Field10);
                        //TODO: string review = et.Field12;


                        CurrentUser.EndRequestedTask(CurrentTask, startTime, endTime, taskLength, stars, /*review*/"TODO");
                    } catch (Exception ex) {
                        exception = true;
                        View.ShowErrorMessge(ex.Message);
                    }
                    break;
            }

            if (!exception) {
                UsersList.WriteJsonFile();
                TasksList.WriteJsonFile();

                View.Close();
            } else {
                CurrentTask = backup;
            }
        }

        public void OnAcceptorLabel(object sender, EventArgs e) {
            //TODO: vedere se si puo' mettere che anche se si apre un profilo vedendo le task di un altro profilo non si possa premere sulle info del primo profilo da cui si ha aperto il secondo
            if (!IsViewerAcceptor())
                View.OpenUserDetailsForm(CurrentTask.AcceptorNickname, EntityUser.GetEntity(CurrentUser));
        }

        public void OnRequesterLabel(object sender, EventArgs e) {
            if (!IsViewerRequester())
                View.OpenUserDetailsForm(CurrentTask.RequesterNickname, EntityUser.GetEntity(CurrentUser));
        }



        public static TaskDetails.FormState GetFormState(string taskId, EntityUser e) {
            User u = EntityUser.GetUser(e);
            Task t = TasksList.GetTask(taskId);

            TaskDetails.FormState outp = TaskDetails.FormState.Viewer;

            switch (t.Status) {
                case TPhase.Done:
                    outp = TaskDetails.FormState.Viewer;
                    break;
                case TPhase.Accepted:
                    if (u.Nickname == t.RequesterNickname) {
                        outp = TaskDetails.FormState.ValutateTask;
                    } else if (u.Nickname == t.AcceptorNickname) {
                        outp = TaskDetails.FormState.AcceptorModify;
                    } else {
                        outp = TaskDetails.FormState.Viewer;
                    }
                    break;
                case TPhase.Request:
                    if (u.Nickname == t.RequesterNickname) {
                        outp = TaskDetails.FormState.RequesterModify;
                    } else {
                        outp = TaskDetails.FormState.AcceptTask;
                    }
                    break;
            }

            return outp;
        }

        public void SetForm() {
            switch (View.State) {
                case TaskDetails.FormState.Viewer:
                    View.DisableAll();
                    View.HideAllButtons();
                    break;
                case TaskDetails.FormState.AcceptorModify:
                    View.DisableAll();
                    View.SetActionButton("ABBANDONA TASK");
                    break;
                case TaskDetails.FormState.RequesterModify:
                    View.DisableEndTaskFields();
                    View.SetActionButton("SALVA MODIFICHE");
                    break;
                case TaskDetails.FormState.AcceptTask:
                    View.DisableAll();
                    View.SetActionButton("ACCETTA TASK");
                    break;
                case TaskDetails.FormState.ValutateTask:
                    View.DisableRequestTaskField();
                    View.SetActionButton("TERMINA TASK");
                    break;
            }
        }

        public bool IsViewerRequester() {
            return (CurrentTask.RequesterNickname == CurrentUser.Nickname);
        }

        public bool IsViewerAcceptor() {
            return (CurrentTask.AcceptorNickname == CurrentUser.Nickname);
        }
    }
}
