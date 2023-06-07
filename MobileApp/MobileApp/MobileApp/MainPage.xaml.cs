using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            /*var client = new WebClient();
            var response = client.DownloadString("http://127.0.0.1/CollegeMobile/api/users");*/
        }

        private void btnStudentList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListStudent());
        }

        private void ButtonOmissions_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Omissions());
        }
    }
}
