using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListStudent : ContentPage
    {
        public ListStudent()
        {
            InitializeComponent();
            try
            {
                var client = new WebClient();
                var response = client.DownloadString("http://192.168.0.122/WebCollege/api/Students");
                listStudent.ItemsSource = JsonConvert.DeserializeObject<List<Student>>(response);
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message.ToString(), "OK");
            }

        }

        async private void RefreshViews_Refreshing(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(3000);
                var client = new WebClient();
                var response = client.DownloadString("http://192.168.0.122/WebCollege/api/Students");
                listStudent.ItemsSource = JsonConvert.DeserializeObject<List<Student>>(response);
                MyRefresh.IsRefreshing = false;
            }
            catch (Exception ex)
            {
                _ = DisplayAlert("Ошибка", ex.Message.ToString(), "OK");
            }
        }
    }
}