using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using ToDoTaskApp.Models;

namespace WPF.Views;

public partial class ShowTaskView : UserControl
{
    public ShowTaskView()
    {
        InitializeComponent();
        GetCategories();
    }

    private async void GetCategories()
    {
        List<ToDoTaskDto> model = null;
        HttpClient client = new HttpClient();
        var response = await client.GetAsync("http://localhost:5000/api/tasks");
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<List<ToDoTaskDto>>(message);
            View.ItemsSource = model;
        }
    }
    private async void DeleteTask_Button(object sender, RoutedEventArgs e)
    {
        dynamic content = ((Button) sender).DataContext;
        HttpClient client = new HttpClient();
        var response = await client.DeleteAsync($"http://localhost:5000/api/tasks/{content.Id}");
        if (response.IsSuccessStatusCode)
        {
            GetCategories();
        }
    }

    private async  void Done_Button(object sender, RoutedEventArgs e)
    {
        dynamic content = ((Button) sender).DataContext;
        HttpClient client = new HttpClient();
        var response = await client.PostAsync($"http://localhost:5000/api/tasks/{content.Id}",null);
        if (response.IsSuccessStatusCode)
        {
            GetCategories();
        }
    }
}