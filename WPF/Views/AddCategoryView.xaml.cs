using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;

namespace WPF.Views;

public partial class AddCategoryView : UserControl
{
    public AddCategoryView()
    {
        InitializeComponent();
    }

    
    
    private async void AddCategory_Button(object sender, RoutedEventArgs e)
    {
        HttpClient client = new HttpClient();
        string json = JsonConvert.SerializeObject( new TaskCategoryVM() {Name = Name.Text});
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5000/api/categories", stringContent);
        if (response.IsSuccessStatusCode)
        {
            MessageBox.Show("Success");
            Name.Text = "";
        }
        else
        {
            MessageBox.Show("Fail");
        }
    }

    
}