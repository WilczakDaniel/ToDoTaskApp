using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using ToDoTaskApp.Models;

namespace WPF.Views;

public partial class AddTaskView : UserControl
{
    public AddTaskView()
    {
        InitializeComponent();
    }

    private  async void AddTask_Button(object sender, RoutedEventArgs e)
    {
        HttpClient client = new HttpClient();
        string json = JsonConvert.SerializeObject( new ToDoTaskVM() {TaskName = TaskName.Text, TaskDate = Date.SelectedDate.Value,TaskDescription = TaskDescription.Text,TaskCategoryId = Int32.Parse(CategoryId.Text)});
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5000/api/tasks", stringContent);
        if (response.IsSuccessStatusCode)
        {
            MessageBox.Show("Success");
            TaskName.Text = "";
            Date.Text = "";
            TaskDescription.Text = "";
            CategoryId.Text = "";
        }
        else
        {
            MessageBox.Show("Fail");
        }
    }
    
}