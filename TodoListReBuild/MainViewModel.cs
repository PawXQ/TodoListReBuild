using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TodoListReBuild.Models;
using TodoListReBuild.Presenter;
using TodoListReBuild.Utility;
using static TodoListReBuild.Contract.TaskContract;

namespace TodoListReBuild
{
    internal class MainViewModel : INotifyPropertyChanged, ITaskView
    {
        ITaskPresenter taskPresenter;

        private ObservableCollection<TaskViewModel> _taskViewModels = new ObservableCollection<TaskViewModel>();
        public ObservableCollection<TaskViewModel> TaskViewModels
        {
            get => _taskViewModels;
            private set
            {
                _taskViewModels = value;
                OnPropertyChanged(nameof(TaskViewModels));
            }
        }

        public ICommand AddTaskCommand { get; set; }
        public ICommand ModifyTaskCommand { get; set; }
        public ICommand SaveTaskCommand { get; set; }
        public ICommand RemoveTaskCommand { get; set; }

        private string _addTask = "Add";
        public string AddTask
        {
            get => _addTask;
            set
            {
                _addTask = value;
                OnPropertyChanged(nameof(AddTask));
            }
        }

        private string _taskContent;
        public string TaskContent
        {
            get => _taskContent;
            set
            {
                _taskContent = value;
                OnPropertyChanged(nameof(TaskContent));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            taskPresenter = new TaskPresenter(this);
            this.AddTaskCommand = new RelayCommand(() => AddTaskClick(), () => true);

            this.SaveTaskCommand = new RelayCommand<TaskViewModel>((x) =>
            {
                TaskModel taskModel = new TaskModel(x.Id, x.Content);
                this.taskPresenter.SaveTask(taskModel);
                x.LabelVisibility = Visibility.Visible;
                x.TextBoxVisibility = Visibility.Collapsed;
            }, (x) => true);

            this.ModifyTaskCommand = new RelayCommand<TaskViewModel>((x) =>
            {
                x.LabelVisibility = Visibility.Collapsed;
                x.TextBoxVisibility = Visibility.Visible;
            }, (x) => true);

            this.RemoveTaskCommand = new RelayCommand<TaskViewModel>((x) =>
            {
                TaskModel taskModel = new TaskModel(x.Id, x.Content);
                this.taskPresenter.RemoveTask(taskModel);
            }, (x) => true);
        }

        public void AddTaskClick()
        {
            this.taskPresenter.CreateTask(this._taskContent);
        }

        //public void RemoveTaskClick(TaskViewModel taskViewModel)
        //{
        //    TaskModel taskModel = new TaskModel(taskViewModel.Content);
        //    this.taskPresenter.RemoveTask(taskModel);
        //}

        public void RenderTask(List<TaskModel> tasks)
        {
            List<TaskViewModel> taskViewModels = tasks.Select(x => new TaskViewModel(x.Id, x.Content)).ToList();
            this.TaskViewModels = new ObservableCollection<TaskViewModel>(taskViewModels);
        }
    }
}
