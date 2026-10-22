using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListReBuild.Models;
using static TodoListReBuild.Contract.TaskContract;

namespace TodoListReBuild.Presenter
{
    internal class TaskPresenter : ITaskPresenter
    {
        ITaskView tasksView;

        List<TaskModel> _tasks = new List<TaskModel>();

        public TaskPresenter(ITaskView tasksView)
        {
            this.tasksView = tasksView;
        }

        public void CreateTask(string task)
        {
            TaskModel taskModel = new TaskModel(task);
            this._tasks.Add(taskModel);
            tasksView.RenderTask(this._tasks);
        }

        public void SaveTask(TaskModel taskModel)
        {
            int index = this._tasks.FindIndex(x => x.Id == taskModel.Id);
            {
                this._tasks[index] = taskModel;

                tasksView.RenderTask(this._tasks);
            }
        }

        public void RemoveTask(TaskModel taskModel)
        {
            int index = this._tasks.FindIndex(x => x.Id == taskModel.Id);
            {
                this._tasks.RemoveAt(index);

                tasksView.RenderTask(this._tasks);
            }
        }
    }
}
