using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListReBuild.Models;

namespace TodoListReBuild.Contract
{
    internal class TaskContract
    {
        internal interface ITaskPresenter
        {
            void CreateTask(string content);
            void RemoveTask(TaskModel taskModel); // TaskModel => TaskEntity
            void SaveTask(TaskModel taskModel);
        }
        internal interface ITaskView
        {
            void RenderTask(List<TaskModel> tasks);
        }
    }
}
