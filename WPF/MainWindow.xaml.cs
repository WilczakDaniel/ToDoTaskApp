using System;
using System.Collections.Generic;
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
using WPF.ViewModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Register_Button(object sender, RoutedEventArgs e)
        {
            DataContext = new RegisterViewModel();
        }

        private void AddTask_Button(object sender, RoutedEventArgs e)
        {
            DataContext = new AddTaskViewModel();
        }

        private void ShowTasks_Button(object sender, RoutedEventArgs e)
        {
            DataContext = new ShowTasksViewModel();
        }

        private void AddTaskCategory_Button(object sender, RoutedEventArgs e)
        {
            DataContext = new AddCategoryViewModel();
        }

        private void ShowTaskCategories_Button(object sender, RoutedEventArgs e)
        {
            DataContext = new ShowCategoryViewModel();
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            DataContext = new LoginViewModel();
        }
    }
}