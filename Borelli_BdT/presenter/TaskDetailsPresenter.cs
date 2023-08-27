using System;
using Borelli_BdT.model;
using Borelli_BdT.view;

namespace Borelli_BdT.presenter {
    public class TaskDetailsPresenter {
        private TaskDetails _view;

        private User CurrentUser { get; set; }
        private Task CurrentTask { get; set; }

        public TaskDetailsPresenter(TaskDetails view, string id, EntityUser eu) {
            View = view;

            Task t = TasksList.GetTask(id);
            EntityTask et = EntityTask.GetEntity(t);
            View.CurrentTask = et;

            CurrentUser = UsersList.GetUser(eu.Field1);
            CurrentTask = TasksList.GetTask(id);
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

            switch(View.State) {
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
                        CurrentUser.ReviewTask(CurrentTask, View.CurrentTask.Field2);
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
                        DateTime startTime = DateTime.Parse(View.CurrentTask.Field7);
                        DateTime endTime = DateTime.Parse(View.CurrentTask.Field8);
                        TimeSpan taskLength = TimeSpan.Parse(View.CurrentTask.Field9);
                        float stars = float.Parse(View.CurrentTask.Field10);

                        CurrentUser.EndRequestedTask(CurrentTask,startTime, endTime, taskLength, stars);
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
    }
}
