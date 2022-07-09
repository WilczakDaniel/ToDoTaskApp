using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using ToDoTaskApp.Models;

namespace WPF.Views;

public partial class ShowCategoryView : UserControl
{
    public ShowCategoryView()
    {
        InitializeComponent();
        GetCategories();
    }

    private async void GetCategories()
    {
        List<TaskCategoryDto> model = null;
        HttpClient client = new HttpClient();
        var response = await client.GetAsync("http://localhost:5000/api/categories");
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<List<TaskCategoryDto>>(message);
            View.ItemsSource = model;
        }
    }
    private async void DeleteCategory_Button(object sender, RoutedEventArgs e)
    {
        dynamic content = ((Button) sender).DataContext;
        HttpClient client = new HttpClient();
        var response = await client.DeleteAsync($"http://localhost:5000/api/categories/{content.Id}");
        if (response.IsSuccessStatusCode)
        {
            GetCategories();
        }
    }
}