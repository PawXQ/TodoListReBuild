using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        private Visibility _textVisibility = Visibility.Collapsed;
        public Visibility TextBoxVisibility
        {
            get { return _textVisibility; }
            set
            {
                _textVisibility = value;
                OnPropertyChanged(nameof(TextBoxVisibility));
            }
        }

        private Visibility _modifyButVisibility = Visibility.Visible;
        public Visibility ModifyButVisibility
        {
            get { return _modifyButVisibility; }
            set
            {
                _modifyButVisibility = value;
                OnPropertyChanged(nameof(ModifyButVisibility));
            }
        }

        private Visibility _saveButVisibility = Visibility.Collapsed;
        public Visibility SaveButVisibility
        {
            get { return _saveButVisibility; }
            set
            {
                _saveButVisibility = value;
                OnPropertyChanged(nameof(SaveButVisibility));
            }
        }

        private ICommand _detailCommand;
        public ICommand DetailCommand
        {
            get { return _detailCommand; }
            set
            {
                _detailCommand = value;
                OnPropertyChanged(nameof(DetailCommand));
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
