using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TodoListReBuild.Models
{
    internal class TaskViewModel : INotifyPropertyChanged
    {
        public Guid Id;
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        private Visibility _labelVisibility = Visibility.Visible;
        public Visibility LabelVisibility
        {
            get { return _labelVisibility; }
            set
            {
                _labelVisibility = value;
                OnPropertyChanged(nameof(LabelVisibility));
            }
        }

        private Visibility _testVisibility = Visibility.Collapsed;
        public Visibility TextBoxVisibility
        {
            get { return _testVisibility; }
            set
            {
                _testVisibility = value;
                OnPropertyChanged(nameof(TextBoxVisibility));
            }
        }

        public TaskViewModel(Guid id, string content)
        {
            this.Id = id;
            this.Content = content;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
