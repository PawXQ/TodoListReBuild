using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListReBuild.Models
{
    internal class TaskModel // TaskEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Content { get; }
        public TaskModel(Guid id, string content)
        {
            this.Id = id;
            this.Content = content;
        }
        public TaskModel(string content)
        {
            this.Content = content;
        }
    }
}
