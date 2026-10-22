using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TodoListReBuild.Models;

namespace TodoListReBuild.UserControls
{
    /// <summary>
    /// Interaction logic for TaskControlPanel.xaml
    /// </summary>
    public partial class TaskControlPanel : UserControl
    {
        public TaskControlPanel()
        {
            InitializeComponent();
            //DataContext = new MainViewModel();
        }

        public static readonly DependencyProperty DetailCommandProperty = DependencyProperty.Register(
        nameof(DetailCommand),
        typeof(ICommand),
        typeof(TaskControlPanel),
        new PropertyMetadata(default(ICommand), OnDetailCommandChanged, CoerceDetailCommand));
        public ICommand DetailCommand
        {
            get => (ICommand)GetValue(DetailCommandProperty);
            set => SetValue(DetailCommandProperty, value);
        }
        private static void OnDetailCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TaskControlPanel panel = d as TaskControlPanel;
            TaskViewModel viewModel = panel.DataContext as TaskViewModel;
            viewModel.DetailCommand = e.NewValue as ICommand;
        }
        private static object CoerceDetailCommand(DependencyObject d, object baseValue)
        {
            return baseValue;
        }
    }
}
