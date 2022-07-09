using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using ToDoTaskApp.Models;

namespace WPF.Views;

public partial class RegisterView : UserControl
{
    public RegisterView()
    {
        InitializeComponent();
    }

    private async void Register_Button(object sender, RoutedEventArgs e)
    {
        if (Login.Text != "" && Password.Text != "" && Email.Text != "" && RoleId.Text != "")
        {
            HttpClient client = new HttpClient();
            string json = JsonConvert.SerializeObject( new RegisterUserDto (Login.Text , Email.Text , Password.Text, Int32.Parse(RoleId.Text)));
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5000/api/account/register", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Register Success!");
                Login.Text = "";
                Email.Text = "";
                Password.Text = "";
                RoleId.Text = "";
            }
        }
        else
        {
            MessageBox.Show("Fail");
        }
    }
}