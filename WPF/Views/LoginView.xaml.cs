using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using ToDoTaskApp.Models;

namespace WPF.Views;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }

    private async void Login_Button(object sender, RoutedEventArgs e)
    {
        if (Login.Text != "" && Password.Text != "")
        {
            HttpClient client = new HttpClient();
            string json = JsonConvert.SerializeObject( new LoginDto(){Login = Login.Text, Password = Password.Text});
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5000/api/account/login", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Login Success!");
                Login.Text = "";
                Password.Text = "";
            }
        }
        else
        {
            MessageBox.Show("Fail");
        }
    }
}